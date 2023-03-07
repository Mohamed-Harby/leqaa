import React from "react";
import "./Announcement.css";

export const Announcement = ({ card }) => {
  return (
    <div className="announcement">
      <p>{card.announcementDescription}</p>
      <p>{card.announcementTime}</p>
    </div>
  );
};
