import React from 'react'
import "./Members.css"
import Card from '../Card/Card'

function Members() {
  const membersArr = [
    { memberName: "member1", memberBio: "bio1" },
    { memberName: "member2", memberBio: "bio2" },
    { memberName: "member3", memberBio: "bio3" },
    { memberName: "member4", memberBio: "bio4" },
    { memberName: "member5", memberBio: "bio5" },
    { memberName: "member6", memberBio: "bio6" },
    { memberName: "member7", memberBio: "bio7" },
  ];


  return (
    <div className='membersContainer'>
      <h1>Members</h1>
      
      {membersArr.map((member) => {
        return <Card card={member}/>
      })}
    </div>
  );
}

export default Members