import React, { useEffect, useRef, useState } from "react";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Carousel from "../../Components/Carousel/Carousel";
import Dropdown from "../../Components/Dropdown/Dropdown";
import RecentActivities from "../../Components/HomeComponents/RecentActivities/RecentActivities";
import Recommended from "../../Components/HomeComponents/Recommended/Recommended";
import "./Home.css";
import useCookies from "react-cookie/cjs/useCookies";

import Statusbar from "../../Components/Statusbar/Statusbar";
import Card from "../../Components/Card/Card";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import { getWindowSize, useGetWidth } from "../../Custom/useDimension";
import { getUser } from "../../redux/authSlice";
// import CallToolsBar from '../../Components/CallToolsBar/CallToolsBar'
// import TypingBar from '../../Components/TypingBar/TypingBar';

function Home() {
  const recentActivities = useRef(null);
  const recommended = useRef(null);
  const [components, setComponents] = useState("RecentActivities");
  const [show, setShow] = useState(3);
  const auth = useAuth();
  console.log(auth.user);
  const token = getCookies("token");
  console.log(token);
  const width = useGetWidth();

  useEffect(() => {
    if (width <= 768) {
      setShow(2);
      console.log("done");
    } else {
      setShow(3);
    }
  }, [width]);

  console.log(width);
  useEffect(() => {
    console.log("third");
  }, []);

  return (
    <div className="home">
      <Carousel show={show} />
      <div className="btns">
        <button
          onClick={() => setComponents(recentActivities.current.value)}
          value="RecentActivities"
          ref={recentActivities}
        >
          Recent Activities
        </button>
        <button
          onClick={() => setComponents(recommended.current.value)}
          value="Recommended"
          ref={recommended}
        >
          Recommended
        </button>
      </div>

      <>
        {components == "RecentActivities" && <RecentActivities />}
        {components == "Recommended" && <Recommended />}
      </>
    </div>
  );
}

export default Home;
