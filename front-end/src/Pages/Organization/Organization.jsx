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
import {
  getHub,
  getResponseCreatedHub,
  getResponseEditedHub,
  getResponseGetDeleteHubStatus,
  getResponseGetHub,
} from "../../redux/hubSlice";
import { useLocation, useParams } from "react-router-dom";
import Members from "../../Components/HubComponents/Members/Members";
import TypingBar from "../../Components/TypingBar/TypingBar";
import SettingChannel from "../../Components/ChannelComponents/SettingChannel/SettingChannel";

function Organization() {
  const channels = useRef(null);
  const recent = useRef(null);
  const members = useRef(null);
  const setting = useRef(null);
  const [components, setComponents] = useState("Channels");
  const { pathname } = useLocation();
  const [membersList, setMembersList] = useState([]);
  const [hubs, setHubs] = useState([]);
  const responseHubs = useSelector(getResponseUserHubs);
  const responseGetHub = useSelector(getResponseGetHub);
  const responseCreatedHub = useSelector(getResponseCreatedHub);
  const responseEditedHub = useSelector(getResponseEditedHub);
  const responseDeletedHub = useSelector(getResponseGetDeleteHubStatus);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  var size = Object.keys(responseCreatedHub).length;
  const { id } = useParams();

  useEffect(() => {
    dispatch(viewUserHubs(token));
    dispatch(getHub({ token: token, id: id }));
    console.log(responseDeletedHub);
  }, [responseCreatedHub, responseDeletedHub]);

  useEffect(() => {
    console.log(responseHubs);
    setHubs(responseHubs);
  }, [responseHubs]);

  console.log(responseGetHub);

  return (
    <div className="organizationPage">
      <AdditionalSidebar
        setComponents={setComponents}
        setMembersList={setMembersList}
        cards={hubs}
        path={pathname}
      />
      {id ? (
        <div className="organization-section">
          <div className="top">
            <Statusbar
              data={
                Object.keys(responseEditedHub).length
                  ? responseEditedHub
                  : responseGetHub
              }
            />
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
              <button
                onClick={() => setComponents(setting.current.value)}
                value="Setting"
                ref={setting}
              >
                Setting
              </button>
            </div>
          </div>
          <div>
            {components === "Channels" && <ChannelsGrid id={id} />}
            {components === "Announcements" && <Announcements />}
            {components === "Members" && <Members id={id} />}
            {components === "Setting" && <SettingChannel />}
          </div>
          {components === "Announcements" && <TypingBar />}
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
