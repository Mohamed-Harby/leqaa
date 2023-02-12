import React from 'react'
import "./Meeting.css"
import CallToolsBar from "../../Components/CallToolsBar/CallToolsBar";
import PeopleGrid from '../../Components/MeetingComponents/PeopleGrid/PeopleGrid';
import MeetingZoom from '../../Components/MeetingComponents/MeetingZoom/MeetingZoom';
import MeetingChat from '../../Components/MeetingComponents/MeetingChat/MeetingChat';





function Meeting() {
  return (
    <>
      <div className="callPage">

        <div className="content">
          <PeopleGrid />
          <MeetingChat/>
          {/* <MeetingZoom/> */}
        </div>

        
        <CallToolsBar/>
      </div>
    </>
  );
}

export default Meeting