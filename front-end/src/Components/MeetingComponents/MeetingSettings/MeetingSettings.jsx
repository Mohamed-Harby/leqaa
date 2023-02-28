import React, { useCallback, useContext, useEffect, useState } from "react";
import "./MeetingSettings.css";
import { MeetingContext } from "../MeetingUtilities/MeetingContext";


const getAllDevices = async () => {
  try {
    let allDevicesArr = await navigator.mediaDevices.enumerateDevices();
    let output = {}
    output.audioInputDevices = allDevicesArr.filter(
      (device) => device.kind === "audioinput"
    );
    output.videoInputDevices = allDevicesArr.filter(
      (device) => device.kind === "videoinput"
    );

    return output

  } catch (err) {
    console.log(err);
  }
};

function MeetingSettings() {
  const { userDevices, setUserDevices } = useContext(MeetingContext);
  const [audioInputDevices, setAudioInputDevices] = useState([])
  const [videoInputDevices, setVideoInputDevices] = useState([])

  useEffect(() => {
    getAllDevices().then(output => {
      setAudioInputDevices(output.audioInputDevices)
      setVideoInputDevices(output.videoInputDevices)
    })
  })  
  
  
  
  getAllDevices()

  const handleSubmit = () => {
    console.log("hello world")
  }

  return (
    <form onSubmit={handleSubmit} className="meetingSettings">
      <label htmlFor="audio">Choose audio device:</label>
      <select name="audio" id="audio">
        {audioInputDevices.map((device) => {
          return <option value={device.deviceId}>{device.label}</option>;
        })}
      </select>
      <label htmlFor="video">Choose video device:</label>
      <select name="video" id="video">
        {videoInputDevices.map((device) => {
          return <option value={device.deviceId}>{device.label}</option>;
        })}
      </select>
      <button type="submit">Apply</button>{" "}
    </form>
  );
}

export default MeetingSettings;
