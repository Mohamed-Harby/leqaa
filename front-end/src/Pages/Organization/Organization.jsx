import React, { useRef, useState } from "react";
import "./Organization.css";
import Statusbar from "../../Components/Statusbar/Statusbar";
import Announcements from "../../Components/HubComponents/Announcements/Announcements";
import ChannelsGrid from "../../Components/HubComponents/ChannelsGrid/ChannelsGrid";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import {
  getResponse,
  getResponseUserHubs,
  getStatus,
  viewUserHubs,
  viewUserProfile,
} from "../../redux/userSlice";
import { getCookies } from "../../Custom/useCookies";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import { getResponseCreatedHub, getResponseGetHub } from "../../redux/hubSlice";
import { useLocation } from "react-router-dom";
import Members from "../../Components/HubComponents/Members/Members";

function Organization() {
  const channels = useRef(null);
  const recent = useRef(null);
  const members = useRef(null);
  const [components, setComponents] = useState("Channels");
  const { pathname } = useLocation();
  const [hubs, setHubs] = useState([]);
  const responseHubs = useSelector(getResponseUserHubs);
  const responseGetHub = useSelector(getResponseGetHub);
  const responseCreatedHub = useSelector(getResponseCreatedHub);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  var size = Object.keys(responseCreatedHub).length;

  useEffect(() => {
    dispatch(viewUserHubs(token));
  }, []);

  useEffect(() => {
    console.log(responseHubs);
    setHubs(responseHubs);
  }, [responseHubs]);

  return (
    <div className="organizationPage">
      <AdditionalSidebar
        cards={size ? [...hubs, responseCreatedHub] : hubs}
        path={pathname}
      />
      {Object.keys(responseGetHub).length ? (
        <div className="organization-section">
          <div className="top">
            <Statusbar data={responseGetHub} />
            <div className="btns">
              <button
                onClick={() => setComponents(channels.current.value)}
                value="Channels"
                ref={channels}
              >
                Channels
              </button>
              <button
                onClick={() => setComponents(recent.current.value)}
                value="Announcements"
                ref={recent}
              >
                Announcements
              </button>
              <button
                onClick={() => setComponents(members.current.value)}
                value="Members"
                ref={members}
              >
                Members
              </button>
            </div>
          </div>
          <div>
            {components === "Channels" && <ChannelsGrid />}
            {components === "Announcements" && <Announcements />}
            {components === "Members" && <Members />}
          </div>
        </div>
      ) : (
        <div
          style={{
            flex: 3,
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            fontSize: 30,
          }}
        >
          Select Hub Please...
        </div>
      )}
    </div>
  );
}

export default Organization;
