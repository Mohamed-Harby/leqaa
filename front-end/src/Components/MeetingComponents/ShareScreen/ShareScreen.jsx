import React, { useEffect, useRef } from "react";
import "./ShareScreen.css";
import useFullscreenStatus from "../../../Custom/useFullscreenStatus";

function ShareScreen() {
  const screenRef = useRef(null);
  const [isFullscreen, setIsFullscreen] = useFullscreenStatus(screenRef);


  
  const closeScreenShare = async (stream) => {
    stream.getTracks().forEach((track) => track.stop())
    const screen = screenRef.current;
    screen.srcObject = null;
  }

  useEffect(() => {
    let stream;
    const getScreen = async () => {
      try {
        stream = await navigator.mediaDevices.getDisplayMedia({ video: true });
        const screen = screenRef.current;
        screen.srcObject = stream;
        screen.play()
        console.log("video playing")
      } catch(err){
        console.error(err)
      }
    }
    getScreen()

    return () => {
      closeScreenShare(stream);
    };
    

  }, [])

  return (
    <div className="shareScreen">
      <video
        ref={screenRef}
        onDoubleClick={() => setIsFullscreen(!isFullscreen)}
      ></video>
    </div>
  );
}

export default ShareScreen;
