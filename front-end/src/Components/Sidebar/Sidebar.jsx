import React, { useState } from "react";
import "./Sidebar.css";
import { NavLink } from "react-router-dom";
import { FaBars } from "react-icons/fa";
import { BsHouseDoor, BsPeople, BsGear, BsCameraVideo } from "react-icons/bs";
import { VscOrganization } from "react-icons/vsc";
import { AiOutlineYoutube, AiFillCloseCircle } from "react-icons/ai";
import profilepicture from "../../assets/badea.jpg";
import { useAuth } from "../../Custom/useAuth";

function Sidebar() {
  const id = null;
  const [closeSidebar, setCloseSidebar] = useState(false)
  const auth = useAuth()
  return (
    <div className={closeSidebar ? "sidebar sidebarResponsive" : "sidebar"}>
      <ul>
        <li className="top">
          <div className={closeSidebar ? "edit-control" : "control"}>
            <FaBars
              className={closeSidebar ? "showBar" : "bar"}
              onClick={() => setCloseSidebar(false)}
            />
            <AiFillCloseCircle
              className={closeSidebar ? "hideClose" : "close"}
              onClick={() => setCloseSidebar(true)}
            />
          </div>
          <NavLink to="/">
            <BsHouseDoor />
            <span className={closeSidebar ? "hideText" : "text"}>Home</span>
          </NavLink>
          <NavLink to="/chat">
            <BsPeople />
            <span className={closeSidebar ? "hideText" : "text"}>Chat</span>
          </NavLink>
          <NavLink to="/channels">
            <AiOutlineYoutube />
            <span className={closeSidebar ? "hideText" : "text"}>Channels</span>
          </NavLink>
          <NavLink to="/organization">
            <VscOrganization />
            <span className={closeSidebar ? "hideText" : "text"}>
              Organization
            </span>
          </NavLink>
          <NavLink to="/meeting">
            <BsCameraVideo />
            <span className={closeSidebar ? "hideText" : "text"}>Meeting</span>
          </NavLink>
        </li>

        <li className="bottom">
          <NavLink to="/settings">
            <BsGear />
            <span className={closeSidebar ? "hideText" : "text"}>Setting</span>
          </NavLink>
          <NavLink to={`/profile/${auth.user.user?.userName}`}>
            <img src={profilepicture} alt="user" />
            <span className={closeSidebar ? "hideText" : "text"}>{auth.user.user?.userName}</span>
          </NavLink>
        </li>
      </ul>
    </div>
  );
}

export default Sidebar;
