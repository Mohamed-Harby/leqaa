import React from 'react'
import "./Statusbar.css";
import RadiusImg from '../RadiusImg/RadiusImg'
import { BsGear } from "react-icons/bs";
import { FiPhoneCall } from "react-icons/fi";
import { BsCameraVideo } from "react-icons/bs";

// we will need to fetch the user data and display it here in the future, img is for testing only
import profilePicture from "../../assets/badea.jpg";

function Statusbar() {
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
        <FiPhoneCall />
        <BsCameraVideo />
        <BsGear />
      </div>

    </div>
  );
}

export default Statusbar