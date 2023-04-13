import React, { useState } from "react";
import "./TypingBar.css";
import { AiFillFileImage, AiOutlineEdit, AiOutlineSend } from "react-icons/ai";
import { useDispatch, useSelector } from "react-redux";
import { addMsgs, getMsgs, post } from "../../redux/chatSlice";
import { useAuth } from "../../Custom/useAuth";
import { useRef } from "react";
import { getCookies } from "../../Custom/useCookies";
import RadiusImg from "../RadiusImg/RadiusImg";
import { useLocation, useParams } from "react-router-dom";
import { useEffect } from "react";
import {
  deployChannelAnnoucement,
  deployHubAnnoucement,
  getResponseChannelAnnoucement,
} from "../../redux/announcementSlice";

function TypingBar() {
  const dispatch = useDispatch();
  const typingBar = useRef();
  const [text, setText] = useState(null);
  const [base64String, setBase64String] = useState(null);
  const auth = useAuth();
  const token = getCookies("token");
  const { id } = useParams();
  const announcement = useSelector(getResponseChannelAnnoucement);
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
  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(text);
    if (pathname.split("/")[1] == "channel") {
      dispatch(
        deployChannelAnnoucement({
          token: token,
          data: {
            title: "title",
            content: text,
            image: base64String,
            channelId: id,
          },
        })
      );
    } else {
      dispatch(
        deployHubAnnoucement({
          token: token,
          data: {
            title: "title",
            content: text,
            image: base64String,
            hubId: id,
          },
        })
      );
    }
  };
  // useEffect(() => {
  //   console.log(announcement);
  // }, [announcement])
  return (
    <form onSubmit={handleSubmit} className="typingBar">
      <input
        ref={typingBar}
        type="text"
        placeholder="Typing Here..."
        onChange={(x) => setText(x.target.value)}
      />
      <label for="inputTag">
        <span>
          <AiFillFileImage />
        </span>
        <input id="inputTag" type="file" onChange={setImage} />
      </label>
      <button type="submit">
        <AiOutlineSend />
      </button>
    </form>
  );
}

export default TypingBar;
