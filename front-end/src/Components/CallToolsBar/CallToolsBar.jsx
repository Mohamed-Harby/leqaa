import React, { useContext } from 'react'
import "./CallToolsBar.css"
import { FaRegHandPaper } from "react-icons/fa";
import { TbScreenShare } from "react-icons/tb";
import { ImPhoneHangUp } from "react-icons/im";
import {
  BsCameraVideo,
  BsPeople,
  BsChatLeftText,
  BsMicFill,
} from "react-icons/bs";
import { MeetingContext } from '../MeetingComponents/MeetingUtilities/MeetingContext';

function CallToolsBar() {
  const {
    toggleChat,
    setToggleChat,
    toggleMembers,
    setToggleMembers,
    toggleShareScreen,
    setToggleShareScreen,
    toggleOpenCamera,
    setToggleOpenCamera,
  } = useContext(MeetingContext); 

  return (
    <div className="callToolsBar">
      <h3 className="left">Meeting Code</h3>

      <div className="middle">
        <BsMicFill />
        <BsCameraVideo onClick={() => {
          setToggleOpenCamera(!toggleOpenCamera)
          setToggleShareScreen(false)
        }} />
        <FaRegHandPaper />
        <TbScreenShare
          onClick={() => {
            setToggleShareScreen(!toggleShareScreen)
            setToggleOpenCamera(false)
          }}/>
        <ImPhoneHangUp />
      </div>

      <div className="right">
        <BsPeople
          onClick={() => {
            setToggleMembers(!toggleMembers);
            if (toggleChat) {
              setToggleChat(false);
            }
          }}
        />
        <BsChatLeftText
          onClick={() => {
            setToggleChat(!toggleChat);
            if (toggleMembers) {
              setToggleMembers(false);
            }
          }}
        />
      </div>
    </div>
  );
}

export default CallToolsBar