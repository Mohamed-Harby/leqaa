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

function Chat() {
  const allMsgs = useSelector(getAllChat);
  const msgs = useSelector(getChat)
  const dispatch = useDispatch();
  const auth = useAuth();

  const uniqueArray = allMsgs
    ?.slice(0)
    .reverse()
    .reduce((accumulator, current) => {
      if (
        !accumulator.find(
          (item) => item.to === current.to || item.to === current.from
        )
      ) {
        accumulator.push(current);
      }
      return accumulator;
    }, []);


  // useEffect(() => {
  //   dispatch(getAllMsgs());
  // }, []);

  console.log(uniqueArray);
  console.log(allMsgs);

  return (
    <div className="chat">
      <AdditionalSidebar cards={uniqueArray} />
      <div className="chat-section">
        <Statusbar />
        <div className="messages">
          {msgs?.map((msg, index) => {
            return (
              <div
                key={index}
                className={
                  msg.from == auth.user.user?.userName ? "sender" : "receiver"
                }
              >
                {msg.msg}
              </div>
            );
          })}
        </div>
        <TypingBar />
      </div>
    </div>
  );
}

export default Chat;
