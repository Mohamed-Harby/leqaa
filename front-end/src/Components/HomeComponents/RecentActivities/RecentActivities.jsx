import React from "react";
import Card from "../../Card/Card";
import CardJoinMeeting from "../Cards/Meeting/CardJoinMeeting";
import Post from "../Cards/Post/Post";
import "./RecentActivities.css";

function RecentActivities() {
  const arr = [
    {
      postTitle: "post1",
      postTime: "1 Day ago",
      postDescription:
        "Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1Description1",
    },
    {
      meetingTitle: "meeting1",
      meetingTime: "2 Day ago",
      meetingDescription: "Description1",
    },
    {
      postTitle: "post2",
      postTime: "3 Day ago",
      postDescription: "Description2",
    },
    {
      meetingTitle: "meeting2",
      meetingTime: "4 Day ago",
      meetingDescription: "Description2",
    },
    {
      postTitle: "post3",
      postTime: "5 Day ago",
      postDescription: "Description3",
    },
    {
      meetingTitle: "meeting3",
      meetingTime: "6 Day ago",
      meetingDescription: "Description3",
    },
    {
      postTitle: "post4",
      postTime: "7 Day ago",
      postDescription: "Description4",
    },
    {
      meetingTitle: "meeting4",
      meetingTime: "8 Day ago",
      meetingDescription: "Description4",
    },
    {
      postTitle: "post5",
      postTime: "9 Day ago",
      postDescription: "Description5",
    },
  ];
  return (
    <div className="recentactivities">
      {arr.map((item) => {
        const key = Object.keys(item);
        if (key[0] == "postTitle") {
          return <Post card={item} />;
        } else {
          return <CardJoinMeeting card={item} />;
        }
      })}
    </div>
  );
}

export default RecentActivities;
