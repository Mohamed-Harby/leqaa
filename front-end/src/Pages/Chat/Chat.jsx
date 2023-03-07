import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAuth } from "../../Custom/useAuth";

import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Statusbar from "../../Components/Statusbar/Statusbar";
import TypingBar from "../../Components/TypingBar/TypingBar";
import "./Chat.css";
import { useEffect } from "react";
import {
  getAllChat,
  getAllMsgs,
  getChat,
  getMsgs,
} from "../../redux/chatSlice";
import { setCookies } from "../../Custom/useCookies";
import { useLocation } from "react-router-dom";
import Msg from "../../Components/ChatComponents/Msg/Msg";

function Chat() {
  const dispatch = useDispatch();
  const auth = useAuth();
  const { pathname } = useLocation();

  const msgs = [
    { from: "user1", to: 'Leqaa', msg: "msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1msg1" },
    { from: "user2", to: 'Leqaa', msg: "msg2" },
    { from: "user3", to: 'Leqaa', msg: "msg3" },
    { from: "user4", to: 'Leqaa', msg: "msg4" },
    { from: "user5", to: 'Leqaa', msg: "msg5" },
    { from: "user6", to: 'Leqaa', msg: "msg6" },
    { from: "user7", to: 'Leqaa', msg: "msg7" },
    { to: "user7", from: 'Leqaa', msg: "msg7" },
  ];

  return (
    <div className="chat">
      <AdditionalSidebar cards={msgs} path={pathname} />
      <div className="chat-section">
        <Statusbar />
        <div className="messages">
          {msgs?.map((msg, index) => {
            return <Msg msg={msg} />;
          })}
        </div>
        <TypingBar />
      </div>
    </div>
  );
}

export default Chat;
