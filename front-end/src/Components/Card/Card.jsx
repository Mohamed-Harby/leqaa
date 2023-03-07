import React from "react";
import { useDispatch } from "react-redux";
import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import { getChannel } from "../../redux/channelSlice";
import { getMsgs } from "../../redux/chatSlice";
import { getHub } from "../../redux/hubSlice";
import { followUser } from "../../redux/userSlice";
import RadiusImg from "../RadiusImg/RadiusImg";
import "./Card.css";

function Card({ card, path }) {
  const { pathname } = useLocation();
  console.log(pathname);
  console.log(card);
  const cardInformation = card;
  console.log(cardInformation);
  const auth = useAuth();
  const token = getCookies("token");
  const dispatch = useDispatch();
  const handleClick = () => {
    console.log(path);
    path == "/channel" && dispatch(getChannel({ id: card.id, token: token }));
    path == "/hub" && dispatch(getHub({ id: card.id, token: token }));
  };

  return (
    <div className="card" onClick={() => handleClick()}>
      <RadiusImg size="40px" img={cardInformation?.logo? "data:image/png;base64," + cardInformation.logo: null} />

      <div className="content">
        <div className="meeting-created-by">
          {cardInformation?.meetingCreatedBy}
        </div>

        <div className="meeting">
          <div className="meeting-name">{cardInformation?.meetingName}</div>
          {cardInformation?.meetingCreatedTime && (
            <button className="btn">
              {cardInformation?.meetingCreatedBy.includes("scheduled")
                ? "notify me"
                : "join"}
            </button>
          )}
        </div>

        <div className="existing-numbers">
          {cardInformation?.existingNumbers}
        </div>

        <div className="meeting-created-time">
          {cardInformation?.meetingCreatedTime}
        </div>

        {cardInformation?.existingNumbers && (
          <button className="join btn">join</button>
        )}
        {/* ///////////////////////////////////////////////////////////////////////////////// */}
        <div className="post">
          <div className="post-created-by">
            {cardInformation?.postCreatedBy}
          </div>
          <div className="post-created-time">
            {cardInformation?.postCreatedTime}
          </div>
        </div>
        <div className="post-desc">{cardInformation?.postDesc}</div>
        {/* //////////////////////////////////////////////////////////////////////////////////////////// */}
        <div className="msg-by">
          {cardInformation?.to == auth.user.user?.userName
            ? cardInformation?.from
            : cardInformation?.to}
        </div>
        <div className="msg">{cardInformation?.msg}</div>
        {/* ///////////////////////////////////////////////////////////////////////////////////////////// */}
        {path == ("/channel" || "hub") && (
          <>
            <div className="channel-name">{cardInformation?.name}</div>
            <div className="channel-status">{cardInformation?.description}</div>
          </>
        )}

        {/* ////////////////////////////////////////////////////////////////////////////////////////////////// */}
        <div className="member">
          <div className="member-name">{cardInformation?.userName}</div>
          <button className="btn" onClick={() => dispatch(followUser({token: token, data: {followedUserName: cardInformation.userName}}))}>Follow</button>
        </div>
        {/* /////////////////////////////////////////////////////////////////////////////////////////////////// */}
        <div className="announcement">
          <div className="announcement-desc">
            {cardInformation?.announcementDesc}
          </div>
          <div className="announcement-created-time">
            {cardInformation?.announcementCreatedTime}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Card;
