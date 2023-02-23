import React, { useState } from "react";
import "./Statusbar.css";
import RadiusImg from "../RadiusImg/RadiusImg";
import { BsGear } from "react-icons/bs";
import { FiPhoneCall } from "react-icons/fi";
import { BsCameraVideo } from "react-icons/bs";
import Dropdown from "../../Components/Dropdown/Dropdown";

// we will need to fetch the user data and display it here in the future, img is for testing only
import profilePicture from "../../assets/badea.jpg";
import ModalCalling from "../ModalCalling/ModalCalling";
import ModalVideoCalling from "../ModalVideoCalling/ModalVideoCalling";

function Statusbar() {
  const [modalOpenCalling, setModalOpenCalling] = useState(false);
  const [modalOpenVideoCalling, setModalOpenVideoCalling] = useState(false);
  
  const modalCloseCalling = () => {
    setModalOpenCalling(false);
  };

  const modalCloseVideoCalling = () => {
    setModalOpenVideoCalling(false);
  };

  return (
    <div className="statusbar">
      <div className="left">
        <RadiusImg size="50px" img={profilePicture} />
        <div>
          <h3>Person Name</h3>
          <p>Active</p>
        </div>
      </div>

      <div className="right">
        <FiPhoneCall onClick={() => {setModalOpenCalling(true)}}  />
        <BsCameraVideo onClick={() => {setModalOpenVideoCalling(true)}} />
        <Dropdown
          links={[
            { name: "View Profile", to: "profile" },
            { name: "Pin Chat", to: "Link2" },
            { name: "Clear Chat", to: "Link3" },
          ]}
        />
      </div>
      {modalOpenVideoCalling && <ModalVideoCalling modalCloseVideoCalling={modalCloseVideoCalling} modalOpenVideoCalling={modalOpenVideoCalling} />}
      {modalOpenCalling && <ModalCalling modalCloseCalling={modalCloseCalling} />}
    </div>
    
  );
}

export default Statusbar;
