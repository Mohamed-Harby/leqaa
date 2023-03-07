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

function Channels() {
  const dispatch = useDispatch();
  const [channels, setChannels] = useState([]);
  const responseChannels = useSelector(getResponseUserChannels);
  const token = getCookies("token");
  console.log(responseChannels);

  useEffect(() => {
    dispatch(viewUserChannels(token));
  }, []);

  useEffect(() => {
    setChannels(responseChannels);
  }, [responseChannels]);

  return (
    <div className="channelsGrid">
      {channels.map((channel) => {
        return <ChannelCard card={channel} />;
      })}
    </div>
  );
}

export default Channels;
