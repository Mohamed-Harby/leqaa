import React from "react";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./Card.css";

const Card = ({ card, socket, onselectchat }) => {
  // console.log(card, "cardddddddddddddddddddddddddddddddddddddd");
  const handleClick = () => {
    // console.log("test😎😋😋😎😋");
    onselectchat(card);
    socket.emit("join chat", card._id); // ========================>> this will join the chat room
  };

  return (
    <div className="cardChat" onClick={handleClick}>
      <RadiusImg
        img={card?.logo ? "data:image/png;base64," + card.logo : null}
        size={40}
      />
      <div className="content">
        <div>{card.from}</div>
        <div>{card.msg}</div>
      </div>
    </div>
  );
};

export default Card;
