import React from 'react'
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



function CallToolsBar() {
  return (
    <div className="callToolsBar">
      <h3 className="left">Meeting Code</h3>

      <div className="middle">
        <BsMicFill />
        <BsCameraVideo />
        <FaRegHandPaper />
        <TbScreenShare />
        <ImPhoneHangUp />
      </div>

      <div className="right">
        <BsPeople />
        <BsChatLeftText />
      </div>
    </div>
  );
}

export default CallToolsBar