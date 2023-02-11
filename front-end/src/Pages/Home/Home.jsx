import React, { useEffect, useRef, useState } from "react";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Carousel from "../../Components/Carousel/Carousel";
import Dropdown from "../../Components/Dropdown/Dropdown";
import RecentActivities from "../../Components/HomeComponents/RecentActivities/RecentActivities";
import Recommended from "../../Components/HomeComponents/Recommended/Recommended";
import "./Home.css";

import Statusbar from "../../Components/Statusbar/Statusbar";
import Card from "../../Components/Card/Card";
// import CallToolsBar from '../../Components/CallToolsBar/CallToolsBar'
// import TypingBar from '../../Components/TypingBar/TypingBar';

function Home() {
  const recentActivities = useRef(null);
  const recommended = useRef(null);
  const [components, setComponents] = useState("RecentActivities");

  return (
    <div className="home">
      {/* <AdditionalSidebar /> */}
      <Carousel show={3} />
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
      <div className="cards">
        {components == "RecentActivities" && <RecentActivities />}
        {components == "Recommended" && <Recommended />}
      </div>
      <Dropdown links={['Link11', 'Link2', 'Link3']} />
    </div>
  );
}

export default Home;
