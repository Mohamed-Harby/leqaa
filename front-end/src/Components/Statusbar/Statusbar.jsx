import React, { useState } from "react";
import "./Statusbar.css";
import RadiusImg from "../RadiusImg/RadiusImg";
import { BsGear } from "react-icons/bs";
import { FiPhoneCall } from "react-icons/fi";
import { BsCameraVideo } from "react-icons/bs";
import Dropdown from "../../Components/Dropdown/Dropdown";

// we will need to fetch the user data and display it here in the future, img is for testing only
import profilePicture from "../../assets/badea.jpg";

function Statusbar() {
  const [showDropdown, setShowDropdown] = useState(false);
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
        <Dropdown
          links={[
            { name: "Link1", to: "Link1" },
            { name: "Link2", to: "Link2" },
            { name: "Link3", to: "Link3" },
          ]}
        />
      </div>
    </div>
  );
}

export default Statusbar;
