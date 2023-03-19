import React from "react";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAuth } from "../../Custom/useAuth";
import { MdOutlineCancel } from "react-icons/md";
import { getCookies } from "../../Custom/useCookies";
import {
  getHubsWithoutUserHubs,
  getResponseHubsWithoutUserHubs,
} from "../../redux/userSlice";
import { useEffect } from "react";
import HubCard from "../HubComponents/HubCard/HubCard";

const ModalDiscoverHubs = ({ closeModal }) => {
  const [render, setRender] = useState(false);
  const auth = useAuth();
  const dispatch = useDispatch();
  const [hubs, setHubs] = useState([]);
  const HubsWithoutUserHubs = useSelector(getResponseHubsWithoutUserHubs);
  const token = getCookies("token");
  console.log(auth.user.user.userName);

  useEffect(() => {
    dispatch(getHubsWithoutUserHubs({token: token}));
  }, []);

  useEffect(() => {
    setHubs(HubsWithoutUserHubs);
    console.log(hubs);
  }, [HubsWithoutUserHubs]);
  return (
    <div className="modalDiscoverFriends">
      <div className="modalCalling-overlay" onClick={closeModal}></div>
      <div className="modalCalling-content">
        <MdOutlineCancel onClick={closeModal} />
        {Array.isArray(hubs)
          ? hubs.map((item) => {
              return <HubCard card={item} />;
            })
          : null}
      </div>
    </div>
  );
};

export default ModalDiscoverHubs;
