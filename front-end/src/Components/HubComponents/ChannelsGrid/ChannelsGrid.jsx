import React from "react";
import "./ChannelsGrid.css";
// import profilePicture from "../../assets/badea.jpg";
import google from "../../../assets/google.png";
import ChannelCard from "../ChannelCard/ChannelCard";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import {
  getResponseGetHubChannels,
  viewHubChannels,
} from "../../../redux/hubSlice";
import { useState } from "react";
import { useEffect } from "react";

function ChannelsGrid({ id }) {
  const dispatch = useDispatch();
  const token = getCookies("token");
  const recent = useSelector(getResponseGetHubChannels);
  const [channels, setChannels] = useState([]);
  useEffect(() => {
    dispatch(viewHubChannels({ id: id, token: token }));
  }, [id]);

  useEffect(() => {
    console.log(channels);
    setChannels(recent);
  }, [recent]);

  return (
    <div className="channelsGrid">
      {Array.isArray(channels)
        ? channels.map((channel) => {
            return <ChannelCard card={channel} />;
          })
        : null}
    </div>
  );
}

export default ChannelsGrid;
