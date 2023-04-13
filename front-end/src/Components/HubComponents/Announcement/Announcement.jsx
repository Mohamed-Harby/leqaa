import React from "react";
import "./Announcement.css";

export const Announcement = ({ card }) => {
  return (
    <div className="announcement">
      <p>{card.content}</p>
      <p>{card.creationDate}</p>
    </div>
  );
};
