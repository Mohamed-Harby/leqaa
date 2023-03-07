import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAuth } from "../../Custom/useAuth";
import { getCookies } from "../../Custom/useCookies";
import { getResponseUserFriends, viewUsers } from "../../redux/userSlice";
import Card from "../Card/Card";
import "./ModalDiscoverFriends.css";
import { MdOutlineCancel } from "react-icons/md";
import Member from "../ChannelComponents/Member/Member";

const ModalDiscoverFriends = ({ closeModal }) => {
  const auth = useAuth();
  const dispatch = useDispatch();
  const [friends, setFriends] = useState([]);
  const responseFriends = useSelector(getResponseUserFriends);
  const token = getCookies("token");
  console.log(auth.user.user.userName);

  useEffect(() => {
    dispatch(viewUsers(token));
  }, []);

  useEffect(() => {
    setFriends(responseFriends);
  }, [responseFriends]);
  return (
    <div className="modalDiscoverFriends">
      <div className="modalCalling-overlay" onClick={closeModal}></div>
      <div className="modalCalling-content">
        <MdOutlineCancel onClick={closeModal} />
        {friends.map((item) => {
          if (!item.isFollowed && auth.user.user.userName != item.userName) {
            return <Member card={item} />;
          }
        })}
      </div>
    </div>
  );
};

export default ModalDiscoverFriends;
