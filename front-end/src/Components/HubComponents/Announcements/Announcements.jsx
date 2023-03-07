import React from "react";
import { Announcement } from "../Announcement/Announcement";
import "./Announcements.css";

const Announcements = () => {
  const arr = [
    { announcementDescription: "Description1", announcementTime: "1 Day ago" },
    { announcementDescription: "Description2", announcementTime: "2 Day ago" },
    { announcementDescription: "Description3", announcementTime: "3 Day ago" },
    { announcementDescription: "Description4", announcementTime: "4 Day ago" },
  ];
  return (
    <div className="announcements">
      {arr.map((item) => {
        return <Announcement card={item} />;
      })}
    </div>
  );
};

export default Announcements;
