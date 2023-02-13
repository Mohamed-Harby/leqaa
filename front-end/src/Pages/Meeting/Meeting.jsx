import React, { useState } from 'react'
import "./Meeting.css"
import PeopleGrid from '../../Components/MeetingComponents/PeopleGrid/PeopleGrid';
import SmPeopleGrid from '../../Components/MeetingComponents/SmPeopleGrid/SmPeopleGrid';

import CallToolsBar from "../../Components/CallToolsBar/CallToolsBar";
import MeetingChat from '../../Components/MeetingComponents/MeetingChat/MeetingChat';
import MeetingMembers from "../../Components/MeetingComponents/MeetingMembers/MeetingMembers";
import ShareScreen from '../../Components/MeetingComponents/ShareScreen/ShareScreen';
import OpenCamera from '../../Components/MeetingComponents/OpenCamera/OpenCamera';


import { MeetingContext } from '../../Components/MeetingComponents/MeetingUtilities/MeetingContext';




function Meeting() {
  const [toggleChat, setToggleChat] = useState(false)
  const [toggleMembers, setToggleMembers] = useState(false);
  const [toggleShareScreen, setToggleShareScreen] = useState(false);
  const [toggleOpenCamera, setToggleOpenCamera] = useState(false);

  
  

  console.log("toggle chat is " + toggleChat)
  console.log("toggle Members is " + toggleMembers);

  return (
    <MeetingContext.Provider
      value={{
        toggleChat,
        setToggleChat,
        toggleMembers,
        setToggleMembers,
        toggleShareScreen,
        setToggleShareScreen,
        toggleOpenCamera,
        setToggleOpenCamera,
      }}
    >
      <div className="callPage">
        <div className="content">
          {(!toggleShareScreen && !toggleOpenCamera)  && <PeopleGrid />}
          {toggleShareScreen  && <ShareScreen />}
          {toggleOpenCamera  && <OpenCamera />}
          {toggleChat && <MeetingChat />}
          {toggleMembers && <MeetingMembers />}

          {(toggleShareScreen || toggleOpenCamera) && !toggleChat && !toggleMembers && (
            <SmPeopleGrid />
          )}

          {/* <SmPeopleGrid/> */}
        </div>

        <CallToolsBar />
      </div>
    </MeetingContext.Provider>
  );
}

export default Meeting