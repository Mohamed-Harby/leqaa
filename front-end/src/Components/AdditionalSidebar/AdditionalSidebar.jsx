import React, { useState } from "react";
import Card from "../Card/Card";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar({ cards }) {
  const arr = [
    { to: "person1", msg: "msggggggggggggggggggggggggg1" },
    { to: "person2", msg: "msg2" },
    { to: "person3", msg: "msg3" },
    { to: "person4", msg: "msg4" },
    { to: "person5", msg: "msg5" },
    { to: "person6", msg: "msg6" },
    // { channelName: "channel1", channelStatus: "Live Now" },
    // { channelName: "channel2", channelStatus: "Live 3 days ago" },
  ];
  console.log(cards);

  return (
    <div className="additional">
      <Searchbar />
      <div className="cards">
        {arr?.map((item) => {
          return <Card card={item} />;
        })}
      </div>
    </div>
  );
}

export default AdditionalSidebar;
