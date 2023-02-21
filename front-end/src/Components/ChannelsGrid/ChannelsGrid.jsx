import React from 'react'
import "./ChannelsGrid.css"
// import profilePicture from "../../assets/badea.jpg";
import google from "../../assets/google.png";
import ChannelCard from '../ChannelCard/ChannelCard';


function ChannelsGrid() {
  return (
    <div className="channelsGrid">
      

      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />
      <ChannelCard img={google} name="channel Name" />


    </div>
  );
}

export default ChannelsGrid