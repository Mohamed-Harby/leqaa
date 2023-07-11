import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAuth } from "../../Custom/useAuth";

import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Statusbar from "../../Components/Statusbar/Statusbar";
import TypingBar from "../../Components/TypingBar/TypingBar";
import "./Chat.css";
import { useEffect, useState } from "react";
// import { getAllChat, getAllMsgs, getChat, getMsgs } from "../../redu/chatSlice";
import { setCookies, getCookies } from "../../Custom/useCookies";
import { useLocation, useNavigate } from "react-router-dom";
import Msg from "../../Components/ChatComponents/Msg/Msg";
import { io } from "socket.io-client";
import { get, set } from "react-hook-form";
import axios from "axios";
// import { useState } from "react";

function Chat() {
  const dispatch = useDispatch();
  const auth = useAuth();
  const navigate = useNavigate();
  const { pathname } = useLocation();

  const [chats, setChats] = useState([]);
  const [socket, setSocket] = useState(io("http://localhost:6969"));

  console.log(auth.user.user, "😋😋😋😋😋");
  useEffect(() => {
    if (!auth.user.user) {
      navigate("/login");
    }
  }, []);

  useEffect(() => {
    const currentUserObj = auth.user.user;
    socket.emit("setup", currentUserObj); // this will send the user data object to the server
    console.log(currentUserObj, "currentUserObj 🤑🤑");
  }, []);

  useEffect(() => {
    const token = getCookies("token");
    const fetchData = async () => {
      try {
        const response = await fetch("http://localhost:6969/api/chat", {
          headers: { Authorization: `Bearer ${token}` },
        });
        const jsonData = await response.json();
        setChats(jsonData);
        console.log("jsonData🤬🤬🤬", jsonData);
      } catch (error) {
        console.log(error, "✔✔✔");
      }
    };

    fetchData();
  }, []);

  const msgs = [
    { from: "user1", to: "Leqaa", msg: "msg1", _id: 1 },
    { from: "user2", to: "Leqaa", msg: "msg2", _id: 2 },
    { from: "user3", to: "Leqaa", msg: "msg3", _id: 3 },
    { from: "user4", to: "Leqaa", msg: "msg4", _id: 4 },
    { from: "user5", to: "Leqaa", msg: "msg5", _id: 5 },
    { from: "user6", to: "Leqaa", msg: "msg6", _id: 6 },
    { from: "user7", to: "Leqaa", msg: "msg7", _id: 7 },
    { to: "user7", from: "Leqaa", msg: "msg7", _id: 8 },
  ];

  const [chatSelected, setChatSelected] = useState(undefined);
  socket.on("message received", (newMsg) => {
    console.log(newMsg, "newMsg🤑🤑🤑");
    // add the new msg to the msgs array '[[[[[in a useState']]]]] ya frontebd developer 🤬
  });
  return (
    <div className="chat">
      <AdditionalSidebar
        cards={msgs}
        chats={chats}
        socket={socket}
        path={pathname}
        onselectchat={setChatSelected}
      />
      <div className="chat-section">
        <Statusbar />
        <div className="messages">
          {msgs?.map((msg, index) => {
            return <Msg msg={msg} />;
          })}
        </div>
        <TypingBar chat={chatSelected} socket={socket} />
      </div>
    </div>
  );
}

export default Chat;
