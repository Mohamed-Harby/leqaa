import React from "react";
import RadiusImg from "../../RadiusImg/RadiusImg";
import "./Card.css";

const Card = ({ card }) => {
  console.log(card);
  return (
    <div className="cardChat">
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
