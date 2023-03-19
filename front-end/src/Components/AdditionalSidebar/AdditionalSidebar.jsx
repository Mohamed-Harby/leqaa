import React, { useState } from "react";
import CardSidebar from "../ChannelComponents/CardSidebar/CardSidebar";
import Card from "../ChatComponents/Card/Card";
import ModalDiscoverHubs from "../ModalDiscoverHubs/ModalDiscoverHubs";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar({ cards, path, setMembersList }) {
  console.log(cards);
  console.log(path);
  const [modalOpen, setModalOpen] = useState(false);
  const closeModal = () => {
    setModalOpen(false);
  };

  const handleClick = () => {
    console.log("test");
  };

  return (
    <>
      <div className="additional">
        <Searchbar />
        <div className="cards">
          {cards?.map((card) => {
            if (path == "/chat") {
              return <Card card={card} />;
            } else {
              return (
                <CardSidebar setMembersList={setMembersList} card={card} />
              );
            }
          })}
        </div>
        {path.split("/")[1] == "hub" && (
          <button onClick={() => setModalOpen(true)}>More Hubs</button>
        )}
      </div>
      {modalOpen && <ModalDiscoverHubs closeModal={closeModal} />}
    </>
  );
}

export default AdditionalSidebar;
