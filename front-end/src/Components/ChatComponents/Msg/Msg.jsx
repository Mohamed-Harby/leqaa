import React from "react";
import { useAuth } from "../../../Custom/useAuth";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./Msg.css";

const Msg = ({ msg }) => {
  const auth = useAuth();

  return (
    <div className={msg.from == auth.user.user?.userName ? "sender" : "receiver"}>
      <RadiusImg size={40} />
      <div>{msg.msg}</div>
    </div>
  );
};

export default Msg;
