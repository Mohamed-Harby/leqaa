import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import {
  getResponseUserChannels,
  viewUserChannels,
} from "../../../redux/userSlice";
import Card from "../../Card/Card";
import ChannelCard from "../../HubComponents/ChannelCard/ChannelCard";
import "./Channels.css";

function Channels({ channels }) {
  const dispatch = useDispatch();
  const token = getCookies("token");

  return (
    <div className="channelsGrid">
      {channels.map((channel) => {
        return <ChannelCard card={channel} />;
      })}
    </div>
  );
}

export default Channels;
