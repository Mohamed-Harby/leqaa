import React, { useState } from "react";
import "./Sidebar.css";
import { NavLink } from "react-router-dom";
import { FaBars } from "react-icons/fa";
import { BsHouseDoor, BsPeople, BsGear } from "react-icons/bs";
import { AiOutlineYoutube, AiFillCloseCircle } from "react-icons/ai";
import profilepicture from "../../assets/badea.jpg";

function Sidebar() {
  const id = null;
  const [closeSidebar, setCloseSidebar] = useState(false)
  return (
    <div className={closeSidebar ? "sidebar sidebarResponsive" : "sidebar" }>
      <ul>
        <li class="top">
          <div className="control">
            <FaBars className={closeSidebar ? "showBar" : "bar" } onClick={() => setCloseSidebar(false)} />
            <AiFillCloseCircle className={closeSidebar ? "hideClose" : "close" } onClick={() => setCloseSidebar(true)} />
          </div>
          <NavLink to="/">
            <BsHouseDoor />
            <span className={closeSidebar ? "hideText" : "text" }>Home</span>
          </NavLink>
          <NavLink to="/chat">
            <BsPeople />
            <span className={closeSidebar ? "hideText" : "text" }>Chat</span>
          </NavLink>
          <NavLink to="/channels">
            <AiOutlineYoutube />
            <span className={closeSidebar ? "hideText" : "text" }>Channels</span>
          </NavLink>
        </li>

        <li class="bottom">
          <NavLink to="/settings">
            <BsGear />
            <span className={closeSidebar ? "hideText" : "text" }>Setting</span>
          </NavLink>
          <NavLink to={`/profile/${id}`}>
            <img src={profilepicture} alt="user" />
            <span className={closeSidebar ? "hideText" : "text" }>Username</span>
          </NavLink>
        </li>
      </ul>
    </div>
  );
}

export default Sidebar;
