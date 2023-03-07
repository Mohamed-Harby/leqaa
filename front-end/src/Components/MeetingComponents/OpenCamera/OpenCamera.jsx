import React, { useEffect, useRef } from "react";
import "./OpenCamera.css";
import useFullscreenStatus from "../../../Custom/useFullscreenStatus"


function OpenCamera() {
  const videoRef = useRef(null);
  const [isFullscreen, setIsFullscreen] = useFullscreenStatus(videoRef);




  const closeVideo = async (stream) => {
    stream.getTracks().forEach(function (track) {
      if (track.readyState === "live" && track.kind === "video") {
        track.stop();
      }
    });
  }




  // useEffect(() => {
  //   let stream;
  //   const getVideo = async () => {
  //     try {
  //       stream = await navigator.mediaDevices.getUserMedia({ video: true });
  //       const video = videoRef.current;
  //       video.srcObject = stream;
  //       video.play();
  //     } catch (err) {
  //       console.log(err);
  //     }
  //   };
  //   getVideo();

  //   return () => {
  //     closeVideo(stream);
  //   };
  // }, []);


  useEffect(() => {
    let stream; 
    const getVideo = async () => {
      try {
        // stream = await navigator.mediaDevices.getUserMedia({ video: true });
        let allDevicesArr = await navigator.mediaDevices.enumerateDevices()
        // let audioInputDevice = allDevicesArr.find(
        //   (device) =>
        //     device.kind === "audioinput" 
        // );
        let videoInputDevice = allDevicesArr.find(
          (device) =>
            device.kind === "videoinput"
        );

        //? to get all the video input devices in an array. so I can display them later in the meeting settings. and store the device ID 
        // let videoInputDevice = allDevicesArr.filter(
        //   (device) => device.kind === "videoinput"
        // );

        // console.log(videoInputDevice)
        let constraints = {
          // audio: { deviceId: audioInputDevice.deviceId },
          video: { deviceId: videoInputDevice.deviceId },
        };
        stream = await navigator.mediaDevices.getUserMedia(constraints);


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
  }, [])

  


  return (
    <div className="openCamera">
      <video
        ref={videoRef}
        onDoubleClick={() => setIsFullscreen(!isFullscreen)}
      ></video>
    </div>
  );
}

export default OpenCamera;
