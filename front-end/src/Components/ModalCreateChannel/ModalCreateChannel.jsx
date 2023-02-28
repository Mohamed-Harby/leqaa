import { useState } from "react";
import { useDispatch } from "react-redux";
import "./ModalCreateChannel.css";
import { createChannel } from "../../redux/channelSlice";
import { getCookies } from "../../Custom/useCookies";

function ModalCreateChannel() {
  const [channelName, setChannelName] = useState("")
  const [channelDesc, setChannelDesc] = useState("")
  const token = getCookies("token");

  const HandleSubmit = (event) => {
    event.preventDefault();
    // useDispatch(createChannel({
    //   token: token,

    // }))
    console.log(event);
  };

  return (
    <div className="modalCreateChannel">
      <h1>Create Channel</h1>
      <form onSubmit={HandleSubmit} className="box">
        <input type="text" placeholder="Channel Name" />
        <input type="text" placeholder="Description" />
        <button type="submit">Create Channel</button>
      </form>
    </div>
  );
}

export default ModalCreateChannel;
