import React, { useState } from "react";
import Card from "../Card/Card";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar() {
  const arr = [
    { msgBy: "person1", msg: "msggggggggggggggggggggggggg1" },
    { msgBy: "person2", msg: "msg2" },
    { msgBy: "person3", msg: "msg3" },
    { msgBy: "person4", msg: "msg4" },
    { msgBy: "person5", msg: "msg5" },
    { msgBy: "person6", msg: "msg6" },
    { channelName: "channel1", channelStatus: "Live Now" },
    { channelName: "channel2", channelStatus: "Live 3 days ago" },
  ];
  return (
    <div className="additional">
        <Searchbar />
      {/* {arr.map((item) => {
        return <Card card={item} />;
      })} */}
    </div>
  );
}

export default AdditionalSidebar;
