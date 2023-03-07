import React, { useState } from "react";
import CardSidebar from "../ChannelComponents/CardSidebar/CardSidebar";
import Card from "../ChatComponents/Card/Card";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar({ cards, path }) {
  console.log(cards);
  console.log(path);

  return (
    <div className="additional">
      <Searchbar />
      <div className="cards">
        {cards?.map((card) => {
          if (path == "/chat") {
            return <Card card={card} />;
          } else {
            return <CardSidebar card={card} />;
          }
        })}
      </div>
    </div>
  );
}

export default AdditionalSidebar;
