import React from "react";
import { useDispatch } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import { followUser } from "../../../redux/userSlice";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./Member.css";

const Member = ({ card }) => {
  const dispatch = useDispatch()
  const token = getCookies('token')
  return (
    <div className="member">
      <RadiusImg size={40} />
      <div className="content">
        <div>{card.userName}</div>
        <div>{card.email}</div>
      </div>
      {!card.isFollowed && <button onClick={() => dispatch(followUser({token: token, data:{followedUserName: card.userName}}))}>Follow</button>}
    </div>
  );
};

export default Member;
