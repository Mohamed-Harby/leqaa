import React from "react";
import Card from "../../Card/Card";
import CardJoinMeeting from "../Cards/Meeting/CardJoinMeeting";
import Post from "../Cards/Post/Post";
import "./RecentActivities.css";

function RecentActivities() {
  const arr = [
    {
      title: "post1",
      postTime: "1 Day ago",
      content:
        "Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1",
    },
    {
      meetingTitle: "meeting1",
      meetingTime: "2 Day ago",
      meetingDescription: "Description1",
    },
    {
      title: "post2",
      postTime: "3 Day ago",
      content: "Description2",
    },
    {
      meetingTitle: "meeting2",
      meetingTime: "4 Day ago",
      meetingDescription: "Description2",
    },
    {
      title: "post3",
      postTime: "5 Day ago",
      content: "Description3",
    },
    {
      meetingTitle: "meeting3",
      meetingTime: "6 Day ago",
      meetingDescription: "Description3",
    },
    {
      title: "post4",
      postTime: "7 Day ago",
      content: "Description4",
    },
    {
      meetingTitle: "meeting4",
      meetingTime: "8 Day ago",
      meetingDescription: "Description4",
    },
    {
      title: "post5",
      postTime: "9 Day ago",
      content: "Description5",
    },
  ];
  return (
    <div className="recentactivities">
      {arr.map((item, index) => {
        const key = Object.keys(item);
        if (key[0] == "title") {
          return <Post key={index} card={item} />;
        } else {
          return <CardJoinMeeting key={index} card={item} />;
        }
      })}
    </div>
  );
}

export default RecentActivities;
