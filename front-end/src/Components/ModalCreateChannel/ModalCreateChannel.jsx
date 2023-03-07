import { useEffect, useState } from "react";
import "./ModalCreateChannel.css";

import { useDispatch, useSelector } from "react-redux";
import { createChannel, getResponseChannel, getResponseCreatedChannel } from "../../redux/channelSlice";
import { getCookies } from "../../Custom/useCookies";
import { getResponse, getStatus, viewUserProfile } from "../../redux/userSlice";
import { useNavigate } from "react-router-dom";

function ModalCreateChannel({ modalClose }) {
  const [channelName, setChannelName] = useState("");
  const [channelDesc, setChannelDesc] = useState("");
  const [user, setUser] = useState({});
  const responseUser = useSelector(getResponse);
  const responseChannel = useSelector(getResponseCreatedChannel);
  const token = getCookies("token");
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const HandleSubmit = (e) => {
    e.preventDefault();
    dispatch(
      createChannel({
        token: token,
        data: {
          name: channelName,
          description: channelDesc,
          hubId: responseUser.hubs[0]?.id ? responseUser.hubs[0].id : null,
        },
      })
    );
    modalClose();
  };

  useEffect(() => {
    dispatch(viewUserProfile(token));
  }, []);

  useEffect(() => {
    responseChannel && navigate("/channel");
  }, [responseChannel]);

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
