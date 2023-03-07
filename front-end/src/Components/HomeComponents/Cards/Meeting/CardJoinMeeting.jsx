import React from "react";
import "./CardJoinMeeting.css";

const CardJoinMeeting = ({ card }) => {
  return (
    <div className="cardJoinMeeting">
      <div className="header">{card.meetingTitle}</div>
      <div className="body">
        <div>{card.meetingDescription}</div>
        <button>
          {card.meetingDescription.includes("scheduled") ? "notify me" : "join"}
        </button>
      </div>
      <div className="footer">{card.meetingTime}</div>
    </div>
  );
};

export default CardJoinMeeting;
