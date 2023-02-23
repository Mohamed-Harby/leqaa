import React, { useRef, useState, useEffect } from 'react'
import "./Meeting.css"
import PeopleGrid from '../../Components/MeetingComponents/PeopleGrid/PeopleGrid';

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
  const [toggleMic, setToggleMic] = useState(false)
  const pageRef = useRef(null)


  const [audioStream, setAudioStream] = useState(null)
  const getMic = async () => {
    try {
      const mediaStream = await navigator.mediaDevices.getUserMedia({audio: true,})
      setAudioStream(mediaStream)
    } catch(err) {
      console.log(err)
    }
    console.log("mic running")
  }
  
  const toggleMicFunc = async () => {
    if (audioStream) {
      const audioTracks = audioStream.getAudioTracks();
      if(audioTracks.length > 0){
        audioTracks[0].enabled = !audioTracks[0].enabled
        setToggleMic(!audioTracks[0].enabled)
      }
    }
  }
    
    
  
  useEffect( () => {
    getMic()
  }, [])

  


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
        toggleMic,
        setToggleMic,
        toggleMicFunc,
      }}
    >
      <div className="callPage" ref={pageRef}>
        <div className="content">
          {!toggleShareScreen && !toggleOpenCamera && (
            <PeopleGrid numberOfPeopleDisplayed={12} size={4} />
          )}
          {toggleShareScreen && <ShareScreen />}
          {toggleOpenCamera && <OpenCamera />}
          {toggleChat && <MeetingChat />}
          {toggleMembers && <MeetingMembers />}

          {(toggleShareScreen || toggleOpenCamera) &&
            !toggleChat &&
            !toggleMembers && (
              <PeopleGrid numberOfPeopleDisplayed={4} size={1.5} />
            )}
        </div>

        <CallToolsBar />
      </div>
    </MeetingContext.Provider>
  );
}

export default Meeting