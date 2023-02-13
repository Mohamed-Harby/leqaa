import React from 'react'
import "./SmPeopleGrid.css"
import MeetingPersonCard from "../MeetingPersonCard/MeetingPersonCard";
import profilePicture from "../../../assets/badea.jpg";


function SmPeopleGrid() {
  return (
    <div className="smPeopleGrid">
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />

      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
    </div>
  );
}

export default SmPeopleGrid