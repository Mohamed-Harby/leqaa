import React from 'react'
import "./MeetingMembers.css";
import MeetingMemberCard from '../MeetingMemberCard/MeetingMemberCard';

function MeetingMembers() {
  return (
    <div className="MeetingMembers">

      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      
      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      <MeetingMemberCard name="Person Name"/>
      


    </div>
  );
}

export default MeetingMembers