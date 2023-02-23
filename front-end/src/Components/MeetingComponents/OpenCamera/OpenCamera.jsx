import React, { useEffect, useRef } from "react";
import "./OpenCamera.css";


function OpenCamera() {
  const videoRef = useRef(null);

  const closeVideo = async (stream) => {
    stream.getTracks().forEach(function (track) {
      if (track.readyState === "live" && track.kind === "video") {
        track.stop();
      }
    });
  }


  



  useEffect(() => {
    let stream;
    const getVideo = async () => {
      try {
        stream = await navigator.mediaDevices.getUserMedia({ video: true });
        const video = videoRef.current;
        video.srcObject = stream;
        video.play();
      } catch (err) {
        console.log(err);
      }
    };
    getVideo();

    return () => {
      closeVideo(stream);
    };
  }, []);
  


  return (
    <div className="openCamera">
      <video ref={videoRef}></video>
    </div>
  );
}

export default OpenCamera;
