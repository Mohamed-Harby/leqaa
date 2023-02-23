import React from 'react'
import "./MeetingMemberCard.css"
import RadiusImg from "../../RadiusImg/RadiusImg";


function MeetingMemberCard(props) {
  return (
    <div className="meetingMemberCard">
      <RadiusImg size="50px" img={props.img} />
      <h4>{props.name}</h4>
    </div>
  );
}

export default MeetingMemberCard