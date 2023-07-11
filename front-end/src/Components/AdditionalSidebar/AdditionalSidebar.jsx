import React, { useState } from "react";
import CardSidebar from "../ChannelComponents/CardSidebar/CardSidebar";
import Card from "../ChatComponents/Card/Card";
import ModalDiscoverHubs from "../ModalDiscoverHubs/ModalDiscoverHubs";
import Searchbar from "../Searchbar/Searchbar";
import "./AdditionalSidebar.css";

function AdditionalSidebar({
  socket,
  chats,
  cards,
  path,
  setMembersList,
  setComponents,
  onselectchat,
}) {
  console.log(cards);
  console.log(path);
  const [modalOpen, setModalOpen] = useState(false);
  const closeModal = () => {
    setModalOpen(false);
  };

  const handleClick = () => {
    // console.log("test😎😋😋😎😋");
    // onselectchat();
  };

  return (
    <>
      <div className="additional">
        <Searchbar />
        <div className="cards">
          {/* {cards?.map((card) => {
            if (path == "/chat") {
              return <Card socket={socket} card={card} onClick={handleClick} />;
            } else {
              return (
                <CardSidebar
                  setComponents={setComponents}
                  setMembersList={setMembersList}
                  card={card}
                />
              );
            }
          })} */}
          {chats.map((chat) => {
            if (path == "/chat") {
              return (
                <Card
                  socket={socket}
                  card={chat}
                  onClick={handleClick}
                  onselectchat={onselectchat}
                />
              );
            } else {
              return (
                <CardSidebar
                  setComponents={setComponents}
                  setMembersList={setMembersList}
                  card={chat}
                />
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
