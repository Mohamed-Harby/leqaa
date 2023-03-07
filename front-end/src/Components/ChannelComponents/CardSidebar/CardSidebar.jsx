import React from "react";
import { useDispatch } from "react-redux";
import { useLocation } from "react-router-dom";
import { getCookies } from "../../../Custom/useCookies";
import { getChannel } from "../../../redux/channelSlice";
import { getHub } from "../../../redux/hubSlice";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./CardSidebar.css";

const CardSidebar = ({ card }) => {
  const token = getCookies("token");
  const dispatch = useDispatch();
  const { pathname } = useLocation();
  const handleClick = () => {
    console.log(pathname);
    pathname == "/channel" &&
      dispatch(getChannel({ id: card.id, token: token }));
    pathname == "/hub" && dispatch(getHub({ id: card.id, token: token }));
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
