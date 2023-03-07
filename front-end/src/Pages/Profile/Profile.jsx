import React, { useEffect } from "react";
import { useState } from "react";
import { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import ProfileBar from "../../Components/ProfileBar/ProfileBar";
import Activities from "../../Components/ProfileComponents/Activities/Activities";
import Channels from "../../Components/ProfileComponents/Channels/Channels";
import Friends from "../../Components/ProfileComponents/Friends/Friends";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import { getResponse, getStatus, viewUserProfile } from "../../redux/userSlice";
import "./Profile.css";

function Profile() {
  const activities = useRef(null);
  const channels = useRef(null);
  const friends = useRef(null);
  const [components, setComponents] = useState("Activities");
  const auth = useAuth();
  const [user, setUser] = useState({}) 
  const response = useSelector(getResponse)
  const status = useSelector(getStatus)
  const token = getCookies("token");
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(viewUserProfile(token))
    // setUser(response)
  }, [])

  useEffect(() => {
    setUser(response)
  }, [status])



console.log(user);

  return (
    <div className="profile">
      <ProfileBar user={user} />
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
      <>
        {components == "Activities" && <Activities />}
        {components == "Channels" && <Channels />}
        {components == "Friends" && <Friends />}
      </>
    </div>
  );
}

export default Profile;
