import React from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router-dom";
import { getCookies } from "../../../Custom/useCookies";
import { joinHub } from "../../../redux/userSlice";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./HubCard.css";

const HubCard = ({ card }) => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const token = getCookies('token')
  return (
    <div className="hub">
      <RadiusImg size={40} />
      <div className="content">
        <div onClick={() => navigate(`/hub/${card.id}`)}>{card.name}</div>
        <div>{card.description}</div>
      </div>
      <button onClick={() => dispatch(joinHub({token: token, data: {id: card.id}}))}>Join</button>
    </div>
  );
};

export default HubCard;
