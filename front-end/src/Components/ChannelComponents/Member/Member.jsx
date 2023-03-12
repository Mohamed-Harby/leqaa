import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { getCookies } from "../../../Custom/useCookies";
import { followUser } from "../../../redux/userSlice";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./Member.css";

const Member = ({ card }) => {
  const dispatch = useDispatch();
  const [follow, setFollow] = useState(card.isFollowed)
  const token = getCookies("token");
  const navigate = useNavigate()
  const handleClick = () => {
    console.log(follow);
    setFollow(!follow)
    dispatch(
      followUser({ token: token, data: { followedUserName: card.userName } })
    );
    navigate('/')
  };
  return (
    <div className="member">
      <RadiusImg size={40} />
      <div className="content">
        <div>{card.userName}</div>
        <div>{card.email}</div>
      </div>
      <button onClick={() => handleClick()}>
        {follow ? "Unfollow" : "Follow"}
      </button>
    </div>
  );
};

export default Member;
