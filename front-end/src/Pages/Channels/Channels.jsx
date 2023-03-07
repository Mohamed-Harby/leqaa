import React, { useRef, useState } from "react";
import "./Channels.css";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Statusbar from "../../Components/Statusbar/Statusbar";
import TypingBar from "../../Components/TypingBar/TypingBar";
import { useLocation } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import {
  getResponseUserChannels,
  getStatus,
  viewUserChannels,
} from "../../redux/userSlice";
import { getCookies } from "../../Custom/useCookies";
import {
  getResponseChannel,
  getResponseCreatedChannel,
  getResponseGetChannel,
} from "../../redux/channelSlice";
import Recent from "../../Components/ChannelComponents/Recent/Recent";
import Member from "../../Components/ChannelComponents/Member/Member";
import Members from "../../Components/ChannelComponents/Members/Members";

function Channels() {
  const recent = useRef(null);
  const members = useRef(null);
  const [components, setComponents] = useState("Recent");
  const { pathname } = useLocation();
  const [channels, setChannels] = useState([]);
  const responseChannels = useSelector(getResponseUserChannels);
  const responseGetChannel = useSelector(getResponseGetChannel);
  const responseCreatedChannel = useSelector(getResponseCreatedChannel);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  var size = Object.keys(responseCreatedChannel).length;

  useEffect(() => {
    dispatch(viewUserChannels(token));
  }, []);

  useEffect(() => {
    setChannels(responseChannels);
  }, [responseChannels]);

  return (
    <div className="channelsPage">
      <AdditionalSidebar cards={channels} path={pathname} />
      {Object.keys(responseGetChannel).length ? (
        <div className="channel-section">
          <div className="top">
            <Statusbar data={responseGetChannel} />
            <div className="btns">
              <button
                onClick={() => setComponents(recent.current.value)}
                value="Recent"
                ref={recent}
              >
                Recent
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
            {components === "Recent" && <Recent />}
            {components === "Members" && <Members />}
          </div>
          {components === "Recent" && <TypingBar />}
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
          Select Channel Please...
        </div>
      )}
    </div>
  );
}

export default Channels;
