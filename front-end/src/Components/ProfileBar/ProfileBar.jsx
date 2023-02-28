import React from "react";
import RadiusImg from "../RadiusImg/RadiusImg";
import "./ProfileBar.css";
import { AiOutlineMessage } from "react-icons/ai";
import { FiSettings } from "react-icons/fi";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { buyPlan, getResponse } from "../../redux/userSlice";
import { getCookies } from "../../Custom/useCookies";
import Dropdown from "../Dropdown/Dropdown";

function ProfileBar({ user }) {
  const dispatch = useDispatch();
  const response = useSelector(getResponse);
  const token = getCookies("token");
  // useEffect(() => {
  //   dispatch(buyPlan({ data: { planType: "premium" }, token: token }));
  // }, []);

  // useEffect(() => {
  //   console.log(response);
  // }, [response]);
  return (
    <div className="profilebar">
      <div className="left">
        <RadiusImg
          img={"data:image/png;base64," + user.profilePicture}
          size={40}
        />
        <div>
          <span>{user.userName}</span>
          <span>{user.plans?.length ? user.plans[0].type : 'Free'}</span>
        </div>
      </div>
      <div className="right">
        <AiOutlineMessage />
        <Dropdown
          links={[
            { name: "Link 1", to: "Link1" },
            { name: "Link 2", to: "Link2" },
            { name: "Link 3", to: "Link3" },
          ]}
        />
      </div>
    </div>
  );
}

export default ProfileBar;
