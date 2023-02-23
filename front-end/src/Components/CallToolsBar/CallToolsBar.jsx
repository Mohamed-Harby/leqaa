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
  BsMicMuteFill,
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
    toggleMic,
    // setToggleMic,
    toggleMicFunc,
  } = useContext(MeetingContext); 

  return (
    <div className="callToolsBar">
      <h3 className="left">Meeting Code</h3>

      <div className="middle">
        {toggleMic ? (
          <BsMicMuteFill
            className="icon"
            onClick={() => {
              toggleMicFunc();
            }}
          />
        ) : (
          <BsMicFill
            className="icon"
            onClick={() => {
              toggleMicFunc();
            }}
          />
        )}

        <BsCameraVideo
          className="icon"
          onClick={() => {
            setToggleOpenCamera(!toggleOpenCamera);
            setToggleShareScreen(false);
          }}
        />
        <FaRegHandPaper className="icon" />
        <TbScreenShare
          className="icon"
          onClick={() => {
            setToggleShareScreen(!toggleShareScreen);
            setToggleOpenCamera(false);
          }}
        />
        <ImPhoneHangUp className="icon" />
      </div>

      <div className="right">
        <BsPeople
          className="icon"
          onClick={() => {
            setToggleMembers(!toggleMembers);
            if (toggleChat) {
              setToggleChat(false);
            }
          }}
        />
        <BsChatLeftText
          className="icon"
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