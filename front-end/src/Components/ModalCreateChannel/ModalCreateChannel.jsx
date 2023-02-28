import { useState } from "react";
import "./ModalCreateChannel.css";

import { useDispatch } from "react-redux";
import {
  createChannel,
  getResponse,
  getError,
  getStatus,
} from "../../redux/channelSlice";
import { getCookies } from "../../Custom/useCookies";



function ModalCreateChannel() {
  const token = getCookies("token");
  const [channelName, setChannelName] = useState("");
  const [channelDesc, setChannelDesc] = useState("");
  const dispatch = useDispatch();


  const HandleSubmit = (e) => {
    e.preventDefault();
    dispatch(
      createChannel({
        token: token,
        name: channelName,
        description: channelDesc,
      })
    );
    console.log(getResponse);
  };



  return (
    <div className="modalCreateChannel">
      <h1>Create Channel</h1>
      <form onSubmit={HandleSubmit} className="box">
        <input
          type="text"
          placeholder="Channel Name"
          name="channel_name"
          onChange={(e) => setChannelName(e.target.value)}
        />
        <input
          type="text"
          placeholder="Description"
          name="channel_desc"
          onChange={(e) => setChannelDesc(e.target.value)}
        />
        <button type="submit">Create Channel</button>
      </form>
    </div>
  );
}

export default ModalCreateChannel;
