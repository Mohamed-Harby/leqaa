import React, { useRef, useState } from "react";
import "./Channels.css";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Statusbar from "../../Components/Statusbar/Statusbar";
import TypingBar from "../../Components/TypingBar/TypingBar";
import RecentActivities from "../../Components/HomeComponents/RecentActivities/RecentActivities";
import Members from "../../Components/Members/Members";


function Channels() {
  const recent = useRef(null);
  const members = useRef(null);
  const [components, setComponents] = useState("Recent");
  

  return (
    <div className="channelsPage">
      <AdditionalSidebar />
      <div className="channel-section">
        <div className="top">
          <Statusbar />
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

        <div >
          {components === "Recent" && <RecentActivities />}
          {components === "Members" && <Members />}
        </div>
        
        {components === "Recent" && <TypingBar />}
      </div>
    </div>
  );
}

export default Channels;
