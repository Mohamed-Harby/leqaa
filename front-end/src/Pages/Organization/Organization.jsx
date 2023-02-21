import React, {  useRef, useState } from "react";
import "./Organization.css";
import Statusbar from "../../Components/Statusbar/Statusbar";
import RecentActivities from "../../Components/HomeComponents/RecentActivities/RecentActivities";
import Members from "../../Components/Members/Members";
import ChannelsGrid from "../../Components/ChannelsGrid/ChannelsGrid";


function Organization() {
  const channels = useRef(null);
  const recent = useRef(null);
  const members = useRef(null);
  const [components, setComponents] = useState("Channels");


  return (
    <div className="organizationPage">
      <div className="top">
        <Statusbar />
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
            value="Recent"
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
        {components === "Recent" && <RecentActivities />}
        {components === "Members" && <Members />}
      </div>

    </div>
  );
}

export default Organization;
