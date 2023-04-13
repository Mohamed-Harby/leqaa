import React from "react";
import Member from "../Member/Member";
import "./Members.css";

const Members = ({members}) => {
  console.log(members);
  return (
    <div className="members">
      {members.map((item) => {
        return <Member card={item} />;
      })}
    </div>
  );
};

export default Members;
