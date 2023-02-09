import React from "react";
import RadiusImg from "../RadiusImg/RadiusImg";
import "./Card.css";

function Card(props) {
  const cardInformation = props.card;
  console.log(cardInformation);
  return (
    <div className="card">
      <RadiusImg size="40px" />
      <div className="content">
        <div>{cardInformation?.name}</div>
        <div>{cardInformation?.status}</div>
        <div>{cardInformation?.nameOrg}</div>
      </div>
    </div>
  );
}

export default Card;
