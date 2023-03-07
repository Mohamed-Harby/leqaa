import React, { useContext } from "react";
import "./MeetingContent.css"
import PeopleGrid from "../PeopleGrid/PeopleGrid";
import ShareScreen from "../ShareScreen/ShareScreen";
import OpenCamera from "../OpenCamera/OpenCamera";
import MeetingChat from "../MeetingChat/MeetingChat";
import MeetingMembers from "../MeetingMembers/MeetingMembers";
import { MeetingContext } from "../MeetingUtilities/MeetingContext";


function MeetingContent() {
  const {
    toggleChat,
    toggleMembers,
    toggleShareScreen,
    toggleOpenCamera,
  } = useContext(MeetingContext); 

  return (
    <div className="content">
      <PeopleGrid numberOfPeopleDisplayed={11} size={4} />
      {/* {!toggleShareScreen && !toggleOpenCamera && (
        <PeopleGrid numberOfPeopleDisplayed={12} size={4} />
      )}
      {toggleShareScreen && <ShareScreen />}
      {toggleOpenCamera && <OpenCamera />}
      {toggleChat && <MeetingChat />}
      {toggleMembers && <MeetingMembers />}
      
      {(toggleShareScreen || toggleOpenCamera) &&
        !toggleChat &&
      !toggleMembers && <PeopleGrid numberOfPeopleDisplayed={4} size={1.5} />} */}
      
      {toggleChat && <MeetingChat />}
      {toggleMembers && <MeetingMembers />}
    </div>
  );
}

export default MeetingContent