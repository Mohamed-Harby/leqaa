import React, { useEffect } from "react";
import { useState } from "react";
import { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useParams } from "react-router-dom";
import ProfileBar from "../../Components/ProfileBar/ProfileBar";
import Activities from "../../Components/ProfileComponents/Activities/Activities";
import Channels from "../../Components/ProfileComponents/Channels/Channels";
import Friends from "../../Components/ProfileComponents/Friends/Friends";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import { getResponse, getResponseUser, getStatus, viewUser, viewUserProfile } from "../../redux/userSlice";
import "./Profile.css";

function Profile() {
  const{username} = useParams()
  const activities = useRef(null);
  const channels = useRef(null);
  const followers = useRef(null);
  const followedUsers = useRef(null);
  const [components, setComponents] = useState("Activities");
  const auth = useAuth();
  const [user, setUser] = useState({}) 
  const response = useSelector(getResponseUser)
  const status = useSelector(getStatus)
  const token = getCookies("token");
  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(viewUser({token: token, username: username}))
  }, [])

  useEffect(() => {
    setUser(response)
  }, [response])

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
          onClick={() => setComponents(followers.current.value)}
          value="Followers"
          ref={followers}
        >
          Followers
        </button>
        <button
          onClick={() => setComponents(followedUsers.current.value)}
          value="FollowedUsers"
          ref={followedUsers}
        >
          FollowedUsers
        </button>
      </div>
      <>
        {components == "Activities" && <Activities />}
        {components == "Channels" && <Channels channels={user.channels} />}
        {components == "Followers" && <Friends friends={user.followers} />}
        {components == "FollowedUsers" && <Friends friends={user.followedUsers} />}
      </>
    </div>
  );
}

export default Profile;
