import React, { useEffect, useRef, useState } from "react";
import AdditionalSidebar from "../../Components/AdditionalSidebar/AdditionalSidebar";
import Carousel from "../../Components/Carousel/Carousel";
import Dropdown from "../../Components/Dropdown/Dropdown";
import RecentActivities from "../../Components/HomeComponents/RecentActivities/RecentActivities";
import Recomended from "../../Components/HomeComponents/Recomended/Recomended";
import "./Home.css";

import Statusbar from "../../Components/Statusbar/Statusbar";
import Card from "../../Components/Card/Card";
// import CallToolsBar from '../../Components/CallToolsBar/CallToolsBar'
// import TypingBar from '../../Components/TypingBar/TypingBar';

function Home() {
  const recentActivities = useRef(null);
  const recomended = useRef(null);
  const [components, setComponents] = useState("RecentActivities");

  return (
    <div className="home">
      <AdditionalSidebar />
      <div className="content" style={{ flex: "3" }}>
        <Carousel show={3} />
        <button
          onClick={() => setComponents(recentActivities.current.value)}
          value="RecentActivities"
          ref={recentActivities}
        >
          Recent Activities
        </button>
        <button
          onClick={() => setComponents(recomended.current.value)}
          value="Recomended"
          ref={recomended}
        >
          Recomended
        </button>
        {components == "RecentActivities" && <RecentActivities />}
        {components == "Recomended" && <Recomended />}
      </div>
    </div>
  );
}

export default Home;
