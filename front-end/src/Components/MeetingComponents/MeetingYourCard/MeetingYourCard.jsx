import React, { useContext, useEffect, useState, useRef } from "react";
import "./MeetingYourCard.css";
import RadiusImg from "../../RadiusImg/RadiusImg";
import { MeetingContext } from "../MeetingUtilities/MeetingContext";

import OpenCamera from "../OpenCamera/OpenCamera";
import ShareScreen from "../ShareScreen/ShareScreen";

function MeetingYourCard(props) {
  const {
    toggleShareScreen,
    toggleOpenCamera,
    setToggleOpenCamera,
    setToggleShareScreen,
  } = useContext(MeetingContext);
  const [videoContent, setVideoContent] = useState(false)
  
  useEffect(() => {
    if (toggleOpenCamera || toggleShareScreen) {
      setVideoContent(true);
    } else {
      setVideoContent(false);
    }

    if (toggleOpenCamera) {
      setToggleShareScreen(false);
    }

    if (toggleShareScreen) {
      setToggleOpenCamera(false);
    }
  }, [
    toggleShareScreen,
    toggleOpenCamera,
    setToggleShareScreen,
    setToggleOpenCamera,
  ]);

  return (
    <div
      className="meetingYourCard"
      onClick={() => props.handleActive(props.index)}
    >
      {videoContent ? (
        <div className="videoRunning">
          {toggleOpenCamera && <OpenCamera />}
          {toggleShareScreen && <ShareScreen />}
          <h4>{props.name || "YOU"}</h4>
        </div>
      ) : (
        <div className="noVideo">
          <RadiusImg size="100px" img={props.img} alt={props.name} />
          <h4>{props.name || "YOU"}</h4>
        </div>
      )}
    </div>
  );
}

export default MeetingYourCard;
