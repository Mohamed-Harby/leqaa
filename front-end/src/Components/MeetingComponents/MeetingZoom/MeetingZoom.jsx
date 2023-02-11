import React from 'react'
import "./MeetingZoom.css"
import MeetingPersonCard from "../MeetingPersonCard/MeetingPersonCard";
import profilePicture from "../../../assets/badea.jpg";


function MeetingZoom() {
  return (
    <div className="meetingZoom">
      <div className="sharedScreen"></div>
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
    </div> 
  );
}

export default MeetingZoom