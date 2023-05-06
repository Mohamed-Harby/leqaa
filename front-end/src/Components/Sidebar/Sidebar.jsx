import React, { useState } from "react";
import "./Sidebar.css";
import { NavLink } from "react-router-dom";
import { FaBars } from "react-icons/fa";
import { BsHouseDoor, BsPeople, BsGear, BsCameraVideo } from "react-icons/bs";
import { VscOrganization } from "react-icons/vsc";
import { AiOutlineYoutube, AiFillCloseCircle } from "react-icons/ai";
import profilepicture from "../../assets/badea.jpg";
import { useAuth } from "../../Custom/useAuth";
import { useDispatch, useSelector } from "react-redux";
import { getResponse, getStatus, viewUserProfile } from "../../redux/userSlice";
import RadiusImg from "../RadiusImg/RadiusImg";
import { getCookies } from "../../Custom/useCookies";
import { useEffect } from "react";

function Sidebar() {
  const id = null;
  const [closeSidebar, setCloseSidebar] = useState(false);
  const auth = useAuth();
  const [user, setUser] = useState({});
  const response = useSelector(getResponse);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(viewUserProfile(token));
  }, []);
  useEffect(() => {
    setUser(response);
  }, [status]);
  console.log(auth.user);
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
          <NavLink to="/channel">
            <AiOutlineYoutube />
            <span className={closeSidebar ? "hideText" : "text"}>Channels</span>
          </NavLink>
          <NavLink to="/hub">
            <VscOrganization />
            <span className={closeSidebar ? "hideText" : "text"}>Hubs</span>
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
          <NavLink to={`/profile/${auth?.user?.user?.userName}`}>
            <RadiusImg
              img={
                user?.profilePicture
                  ? "data:image/png;base64," + user.profilePicture
                  : null
              }
              size={40}
            />
            <span className={closeSidebar ? "hideText" : "text"}>
              {auth?.user?.user?.userName}
            </span>
          </NavLink>
        </li>
      </ul>
    </div>
  );
}

export default Sidebar;
