import React from 'react'
import "./Meeting.css"
// import CallToolsBar from "../../Components/CallToolsBar/CallToolsBar";
import PeopleGrid from '../../Components/MeetingComponents/PeopleGrid/PeopleGrid';
// import MeetingZoom from '../../Components/MeetingComponents/MeetingZoom/MeetingZoom';



import { FaRegHandPaper } from "react-icons/fa";
import { TbScreenShare } from "react-icons/tb";
import { ImPhoneHangUp } from "react-icons/im";
import {
  BsCameraVideo,
  BsPeople,
  BsChatLeftText,
  BsMicFill,
} from "react-icons/bs";


function Meeting() {
  return (
    <>
      <div className="callPage">
        <PeopleGrid />
        {/* <MeetingZoom/> */}

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
      </div>
    </>
  );
}

export default Meeting