import React from "react";
import Member from "../Member/Member";
import "./Members.css";

const Members = ({members}) => {
  console.log(members);
  const arr = [
    { nameMember: "member1", descriptionMember: "description1" },
    { nameMember: "member2", descriptionMember: "description1" },
    { nameMember: "member3", descriptionMember: "description1" },
    { nameMember: "member4", descriptionMember: "description1" },
    { nameMember: "member5", descriptionMember: "description1" },
    { nameMember: "member6", descriptionMember: "description1" },
  ];
  return (
    <div className="members">
      {members.map((item) => {
        return <Member card={item} />;
      })}
    </div>
  );
};

export default Members;
