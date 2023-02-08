import React from "react";

function Card(props) {
  const cards = props.cards
  console.log(cards)
  return (
    <div>
      {cards.map((card) => {
        return (
          <div className="card">
            <div>{card.name}</div>
            <div>{card.status}</div>
          </div>
        );
      })}
    </div>
  );
}

export default Card;
