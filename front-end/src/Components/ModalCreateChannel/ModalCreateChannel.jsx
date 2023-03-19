import { useEffect, useState } from "react";
import "./ModalCreateChannel.css";

import { useDispatch, useSelector } from "react-redux";
import {
  createChannel,
  getResponseChannel,
  getResponseCreatedChannel,
} from "../../redux/channelSlice";
import { getCookies } from "../../Custom/useCookies";
import {
  getResponse,
  getResponseUserHubs,
  getStatus,
  viewUserHubs,
  viewUserProfile,
} from "../../redux/userSlice";
import { useNavigate } from "react-router-dom";

function ModalCreateChannel({ modalClose }) {
  const [channelName, setChannelName] = useState("");
  const [channelDesc, setChannelDesc] = useState("");
  const [channelHub, setChannelHub] = useState("");
  const [base64String, setBase64String] = useState();
  const [userHubs, setUserHubs] = useState([]);
  const responseHub = useSelector(getResponseUserHubs);
  const responseChannel = useSelector(getResponseCreatedChannel);
  const token = getCookies("token");
  const dispatch = useDispatch();
  const navigate = useNavigate();
  
  function imageUploaded(x) {
    var file = x.target.files[0];
    console.log(file);
    var reader = new FileReader();
    console.log("next");
    reader.onload = function () {
      setBase64String(reader.result.replace("data:", "").replace(/^.+,/, ""));
    };
    reader.readAsDataURL(file);
  }
  const HandleSubmit = (e) => {
    e.preventDefault();
    dispatch(
      createChannel({
        token: token,
        data: {
          name: channelName,
          description: channelDesc,
          image: base64String,
          hubId: channelHub
        },
      })
    );
    modalClose();
  };

  useEffect(() => {
    dispatch(viewUserHubs(token));
  }, []);

  useEffect(() => {
    setUserHubs(responseHub);
    console.log(responseHub);
  }, [responseHub]);

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
        <div className="input">
          <label htmlFor="planType">Hub</label>
          <select onChange={(x) => setChannelHub(x.target.value)}>
            <option value="">Select Hub</option>
            {responseHub.map((hub) => {
              return <option value={hub.id}>{hub.name}</option>;
            })}
          </select>
        </div>
        <div className="inputFile">
          <label htmlFor="file-upload">
            <div>Choose Channel Picture</div>
            <div className="imgBtn">+</div>
          </label>
          <input id="file-upload" type="file" onChange={imageUploaded} />
        </div>
        <button type="submit">Create Channel</button>
      </form>
    </div>
  );
}

export default ModalCreateChannel;
