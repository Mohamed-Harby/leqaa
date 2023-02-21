import React from "react";
import { useState } from "react";
import { useRef } from "react";
import ProfileBar from "../../Components/ProfileBar/ProfileBar";
import Activities from "../../Components/ProfileComponents/Activities/Activities";
import Channels from "../../Components/ProfileComponents/Channels/Channels";
import Friends from "../../Components/ProfileComponents/Friends/Friends";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import "./Profile.css";

function Profile() {
  const activities = useRef(null);
  const channels = useRef(null);
  const friends = useRef(null);
  const [components, setComponents] = useState("Activities");
  const auth = useAuth();
  console.log(auth.user);
  const token = getCookies("token");
  console.log(token);

  return (
    <div className="profile">
      <ProfileBar />

      <div className="btns">
        <button
          onClick={() => setComponents(activities.current.value)}
          value="Activities"
          ref={activities}
        >
          Activities
        </button>
        <button
          onClick={() => setComponents(channels.current.value)}
          value="Channels"
          ref={channels}
        >
          Channels
        </button>
        <button
          onClick={() => setComponents(friends.current.value)}
          value="Friends"
          ref={friends}
        >
          Friends
        </button>
      </div>
      <div className="cards">
        {components == "Activities" && <Activities />}
        {components == "Channels" && <Channels />}
        {components == "Friends" && <Friends />}
      </div>
    </div>
  );
}

export default Profile;
