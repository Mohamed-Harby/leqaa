import React, { useCallback, useContext, useEffect, useState } from "react";
import "./MeetingSettings.css";
import { MeetingContext } from "../MeetingUtilities/MeetingContext";

const getAllDevices = async () => {
  try {
    let allDevicesArr = await navigator.mediaDevices.enumerateDevices();
    let output = {};
    output.audioInputDevices = allDevicesArr.filter(
      (device) => device.kind === "audioinput"
    );
    output.videoInputDevices = allDevicesArr.filter(
      (device) => device.kind === "videoinput"
    );

    return output;
  } catch (err) {
    console.log(err);
  }
};

function MeetingSettings() {
  const { userDevices, setUserDevices } = useContext(MeetingContext);
  const [audioInputDevices, setAudioInputDevices] = useState([]);
  const [videoInputDevices, setVideoInputDevices] = useState([]);
  const [selectedAudioInput, setSelectedAudioInput] = useState(null);
  const [selectedVideoInput, setSelectedVideoInput] = useState(null);

  useEffect(() => {
    getAllDevices().then((output) => {
      setAudioInputDevices(output.audioInputDevices);
      setVideoInputDevices(output.videoInputDevices);
    });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();
    setUserDevices({
      audioDeviceID: selectedAudioInput,
      videoDeviceID: selectedVideoInput,
    });
    console.log(userDevices);
  };

  return (
    <div className="MeetingSettingsContainer">
      <form onSubmit={handleSubmit}>
        <h1>Meeting Settings</h1>
        <label htmlFor="audio">Audio Device</label>
        <select
          name="audio"
          id="audio"
          onChange={(e) => {
            setSelectedAudioInput(e.target.value);
          }}
        >
          <option value="">Please choose a Mic</option>
          {audioInputDevices.map((device, index) => {
            return (
              <option key={index} value={device.deviceId}>
                {device.label}
              </option>
            );
          })}
        </select>
        <label htmlFor="video">Video Device</label>
        <select
          name="video"
          id="video"
          onChange={(e) => {
            setSelectedVideoInput(e.target.value);
          }}
        >
          <option value="">Please choose a Camera</option>
          {videoInputDevices.map((device, index) => {
            return (
              <option key={index} value={device.deviceId}>
                {device.label}
              </option>
            );
          })}
        </select>
        <button type="submit">Apply</button>
      </form>
    </div>
  );
}

export default MeetingSettings;
