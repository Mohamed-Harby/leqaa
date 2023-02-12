import React, { useState } from "react";
import "./TypingBar.css";
import { AiOutlineSend } from "react-icons/ai";
import { useDispatch, useSelector } from "react-redux";
import { post } from "../../redux/chatSlice";

function TypingBar() {
  const dispatch = useDispatch();
  const [msg, setMsg] = useState(null);
  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(post({msg: msg, from:'user1', to:'user2'}));
  };
  return (
    <form onSubmit={handleSubmit} className="typingBar">
      <input
        type="text"
        placeholder="chat"
        onChange={(x) => setMsg(x.target.value)}
      />
      <button type="submit">
        <AiOutlineSend />{" "}
      </button>
    </form>
  );
}

export default TypingBar;
