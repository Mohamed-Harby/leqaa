import React from "react";
import RadiusImg from "../../../RadiusImg/RadiusImg";
import "./CardJoinMeetingCarousel.css";

const CardJoinMeetingCarousel = ({ card }) => {
  return (
    <div className="cardJoinMeetingCarousel">
      <div className="content">
        <div className="meetingName">{card?.meetingName}</div>
        <div className="creator">
          <RadiusImg size={30} />
          <div className="creatorName">Mohamed Harby</div>
        </div>
        <div className="actionSection">
          <div>
            {card?.existingNumbers > 0
              ? `+${card.existingNumbers} in the room`
              : `Be the first one to join`}
          </div>
          <button>Join</button>
        </div>
      </div>
    </div>
  );
};

export default CardJoinMeetingCarousel;
