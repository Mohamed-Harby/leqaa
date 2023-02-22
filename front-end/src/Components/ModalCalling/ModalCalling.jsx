import React from "react";
import "./ModalCalling.css";
import { useForm } from "react-hook-form";
import { RxSpeakerLoud } from "react-icons/rx";
import { TbScreenShare } from "react-icons/tb";
import { HiOutlinePhoneMissedCall } from "react-icons/hi";
import { MdOutlineCancel } from "react-icons/md";
import useLockBodyScroll from "../../helper/use-lock-body-scroll";
import RadiusImg from "../RadiusImg/RadiusImg";

function ModalCalling({ modalCloseCalling }) {
  useLockBodyScroll();
  
  return (
    <div className="modalCalling">
      <div className="modalCalling-overlay" onClick={modalCloseCalling}></div>
      <div className="modalCalling-content">
        <MdOutlineCancel onClick={modalCloseCalling} />
        <div className="content">
          <RadiusImg size={50} />
          <span>00:00</span>
        </div>
        <div className="btns">
          <span><RxSpeakerLoud /></span>
          <span><TbScreenShare /></span>
          <span><HiOutlinePhoneMissedCall onClick={modalCloseCalling} /></span>
        </div>
      </div>
    </div>
  );
}

export default ModalCalling;
