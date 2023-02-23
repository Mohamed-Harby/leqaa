import React from 'react'
import './ModalVideoCalling.css'
import useLockBodyScroll from "../../helper/use-lock-body-scroll";
import { MdOutlineCancel } from "react-icons/md";
import RadiusImg from "../RadiusImg/RadiusImg";
import { useRef } from 'react';
import { useEffect } from 'react';


const ModalVideoCalling = ({modalCloseVideoCalling, modalOpenVideoCalling}) => {
    useLockBodyScroll();
    const videoRef = useRef(null);
    let stream 
    let screenTracks;
    let sharingScreen = false;




    useEffect(() => {
      getVideo();
      console.log(modalOpenVideoCalling);
    }, [videoRef]);
  
    const getVideo = async () => {
      stream= await navigator.mediaDevices.getUserMedia({video: modalOpenVideoCalling, audio:modalOpenVideoCalling})
      let video = videoRef.current
      video.srcObject = stream
      video.play()
    };

    const handleClick = async () => {
      let videoTrack = stream.getTracks().find(track => track.kind === 'video')
      let audioTrack = stream.getTracks().find(track => track.kind === 'audio')
      console.log(videoTrack.enabled);
      videoTrack.enabled = false
      audioTrack.enabled = false
      console.log(videoTrack.enabled);
      modalCloseVideoCalling()
    }
    
    return (
      <div className="modalCalling">
        <div className="modalCalling-overlay"></div>
        <div className="modalCalling-content">
          <MdOutlineCancel onClick={handleClick} />
          <video ref={videoRef}/>
        </div>
      </div>
    );
  }

export default ModalVideoCalling