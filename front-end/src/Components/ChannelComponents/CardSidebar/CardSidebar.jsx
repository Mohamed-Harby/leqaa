import React from "react";
import { useDispatch } from "react-redux";
import { useLocation, useNavigate } from "react-router-dom";
import { getCookies } from "../../../Custom/useCookies";
import { getChannel } from "../../../redux/channelSlice";
import { getHub } from "../../../redux/hubSlice";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./CardSidebar.css";

const CardSidebar = ({ card, setMembersList, setComponents }) => {
  const token = getCookies("token");
  const dispatch = useDispatch();
  const { pathname } = useLocation();
  const navigate = useNavigate();
  const handleClick = () => {
    console.log(card);
    console.log(pathname.split("/")[1]);
    console.log(token);
    setMembersList(card.joinedUsers);
    if (pathname.split("/")[1] == "channel") {
      setComponents("Recent")
      dispatch(getChannel({ id: card.id, token: token }));
      navigate(`/channel/${card.id}`);
    }
    if (pathname.split("/")[1] == "hub") {
      setComponents("Channels")
      dispatch(getHub({ id: card.id, token: token }));
      navigate(`/hub/${card.id}`);
    }
    
  };
  return (
    <div className="cardSidebar" onClick={() => handleClick()}>
      <RadiusImg
        img={card?.logo ? "data:image/png;base64," + card.logo : null}
        size={40}
      />
      <div className="content">
        <div>{card.name}</div>
        <div>{card.description}</div>
      </div>
    </div>
  );
};

export default CardSidebar;
