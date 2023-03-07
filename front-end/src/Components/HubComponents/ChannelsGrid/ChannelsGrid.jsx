import React from "react";
import "./ChannelsGrid.css";
// import profilePicture from "../../assets/badea.jpg";
import google from "../../../assets/google.png";
import ChannelCard from "../ChannelCard/ChannelCard";

function ChannelsGrid() {
  const arr = [
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
    { logo: google, name: "channel Name" },
  ];
  return (
    <div className="channelsGrid">
      {arr.map((channel) => {
        return <ChannelCard card={channel} />;
      })}
    </div>
  );
}

export default ChannelsGrid;
