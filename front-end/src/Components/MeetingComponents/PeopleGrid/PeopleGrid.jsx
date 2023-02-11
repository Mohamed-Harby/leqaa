import React from 'react'
import "./PeopleGrid.css"
import MeetingPersonCard from '../MeetingPersonCard/MeetingPersonCard';
import profilePicture from "../../../assets/badea.jpg";


function PeopleGrid() {
  return (
    <div className="peopleGrid">
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />
      <MeetingPersonCard img={profilePicture} name="Person Name" />

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

export default PeopleGrid