import React from 'react'
import Card from '../../Card/Card';
import './Activities.css'

function Activities() {
  const arr = [
    {
      meetingCreatedBy: "org1",
      meetingName: "meeting1",
      meetingCreatedTime: "10 minutes ago",
    },
    {
      meetingCreatedBy: "org2 scheduled",
      meetingName: "meeting2",
      meetingCreatedTime: "12 minutes ago",
    },
    {
      postCreatedBy: "person1",
      postCreatedTime: "30 minutes ago",
      postDesc: "Desc1",
    },
    {
      meetingCreatedBy: "org3",
      meetingName: "meeting3",
      meetingCreatedTime: "14 minutes ago",
    },
    {
      meetingCreatedBy: "org4",
      meetingName: "meeting4",
      meetingCreatedTime: "16 minutes ago",
    },
    {
      meetingCreatedBy: "org5",
      meetingName: "meeting5",
      meetingCreatedTime: "18 minutes ago",
    },
    {
      postCreatedBy: "person2",
      postCreatedTime: "50 minutes ago",
      postDesc: "Desc2",
    },
    {
      postCreatedBy: "person3",
      postCreatedTime: "50 minutes ago",
      postDesc: "Desc3",
    },
    { memberName: "member1", memberBio: "bio1" },
    { memberName: "member2", memberBio: "bio2" },
    { announcementCreatedTime: "50 minutes ago", announcementDesc: "Desc1" },
    { announcementCreatedTime: "50 minutes ago", announcementDesc: "Desc2" },
  ];
  return (
    <div className="activities">
      <h1>activities</h1>
      {arr.map((item) => {
        return <Card card={item} />;
      })}
    </div>
  )
}

export default Activities