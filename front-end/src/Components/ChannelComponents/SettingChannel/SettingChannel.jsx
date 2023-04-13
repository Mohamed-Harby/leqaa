import React, { useState } from "react";
import { useEffect } from "react";
import { AiFillFileImage } from "react-icons/ai";
import { useDispatch, useSelector } from "react-redux";
import { useLocation, useNavigate, useParams } from "react-router-dom";
import { getCookies } from "../../../Custom/useCookies";
import {
  deleteChannel,
  editChannel,
  getChannel,
  getResponseGetChannel,
} from "../../../redux/channelSlice";
import {
  deleteHub,
  editHub,
  getHub,
  getResponseGetHub,
} from "../../../redux/hubSlice";
import "./SettingChannel.css";

function SettingChannel() {
  const dispatch = useDispatch();
  const navigate = useNavigate()
  const token = getCookies("token");
  const { id } = useParams();
  const channel = useSelector(getResponseGetChannel);
  const hub = useSelector(getResponseGetHub);
  const [item, setItem] = useState({});
  const [name, setName] = useState(channel.name);
  const [desc, setDesc] = useState(channel.description);
  const [base64String, setBase64String] = useState(null);
  const { pathname } = useLocation();
  const setImage = (x) => {
    var file = x.target.files[0];
    console.log(file);
    var reader = new FileReader();
    console.log("next");
    reader.onload = function () {
      setBase64String(reader.result.replace("data:", "").replace(/^.+,/, ""));
    };
    reader.readAsDataURL(file);
  };
  useEffect(() => {
    if (pathname.split("/")[1] == "channel") {
      dispatch(getChannel({ token: token, id: id }));
    } else {
      dispatch(getHub({ token: token, id: id }));
    }
  }, []);
  useEffect(() => {
    if (pathname.split("/")[1] == "channel") {
      setItem(channel);
    } else {
      setItem(hub);
    }
  }, [channel, hub]);
  const handleSubmit = (e) => {
    e.preventDefault();
    if (pathname.split("/")[1] == "channel") {
      dispatch(
        editChannel({
          token: token,
          data: {channelId:id, name: name, description: desc},
        })
      );
    } else {
      dispatch(
        editHub({
          token: token,
          data: {hubid:id, name: name, description: desc},
        })
      );
    }
  };
  const deleteBtn = () => {
    if (pathname.split("/")[1] == "channel") {
      dispatch(deleteChannel({ token: token, id: id }));
      navigate('/channel')
    } else {
      dispatch(deleteHub({ token: token, id: id }));
      navigate('/hub')
    }
  };
  return (
    <div className="settingChannel">
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          defaultValue={item.name}
          onChange={(x) => setName(x.target.value)}
        />
        <input
          type="text"
          defaultValue={item.description}
          onChange={(x) => setDesc(x.target.value)}
        />
        <label for="inputTag">
          <span>
            <AiFillFileImage /> Choose Image
          </span>
          <input id="inputTag" type="file" onChange={setImage} />
        </label>
        <div className="btns">
          <button type="submit">Edit</button>
          <button onClick={() => deleteBtn()}>Delete</button>
        </div>
      </form>
    </div>
  );
}

export default SettingChannel;
