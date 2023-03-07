import React, { useRef, useState, useEffect } from 'react'
import "./Meeting.css";

import { MeetingContext } from '../../Components/MeetingComponents/MeetingUtilities/MeetingContext';
import CallToolsBar from "../../Components/CallToolsBar/CallToolsBar";
import MeetingSettings from '../../Components/MeetingComponents/MeetingSettings/MeetingSettings';
import MeetingContent from '../../Components/MeetingComponents/MeetingContent/MeetingContent';





function Meeting() {
  const [toggleChat, setToggleChat] = useState(false)
  const [toggleMembers, setToggleMembers] = useState(false);
  const [toggleShareScreen, setToggleShareScreen] = useState(false);
  const [toggleOpenCamera, setToggleOpenCamera] = useState(false);
  const [toggleMic, setToggleMic] = useState(false)
  const [toggleSettings, setToggleSettings] = useState(false)
  const [userDevices, setUserDevices] = useState({})
  const pageRef = useRef(null)


  const [audioStream, setAudioStream] = useState(null)
  const getMic = async () => {
    try {
      const mediaStream = await navigator.mediaDevices.getUserMedia({audio: true,})
      setAudioStream(mediaStream)
    } catch(err) {
      console.log(err)
    }
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
        toggleSettings,
        setToggleSettings,
        userDevices,
        setUserDevices,
      }}
    >
      <div className="meetingPage" ref={pageRef}>
        {toggleSettings ? <MeetingSettings /> : <MeetingContent />}

        <CallToolsBar />
      </div>
    </MeetingContext.Provider>
  );
}

export default Meeting