import React, { useState } from "react";
import "./TypingBar.css";
import { AiOutlineSend } from "react-icons/ai";
import { useDispatch, useSelector } from "react-redux";
import { addMsgs, getMsgs, post } from "../../redux/chatSlice";
import { useAuth } from "../../Custom/useAuth";
import { useRef } from "react";

function TypingBar() {
  const dispatch = useDispatch();
  const typingBar = useRef()
  const [msg, setMsg] = useState(null);
  const auth = useAuth()
  const handleSubmit = (e) => {
    e.preventDefault();
    // dispatch(post({msg: msg, from:auth.user.user.userName, to:'user2'}));
    dispatch(addMsgs({msg: msg, from:auth.user.user.userName, to:'user5'}));
    // dispatch(getMsgs('user3'));
    // dispatch(post({msg: msg, from:'user3', to:auth.user.user.userName}));
    // typingBar.current.value = ''
  };
  return (
    <form onSubmit={handleSubmit} className="typingBar">
      <input
        ref={typingBar}
        type="text"
        placeholder="chat"
        onChange={(x) => setMsg(x.target.value)}
      />
      <button type="submit">
        <AiOutlineSend />
      </button>
    </form>
  );
}

export default TypingBar;
