import React from "react";
import { useEffect } from "react";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAuth } from "../../../Custom/useAuth";
import { getCookies } from "../../../Custom/useCookies";
import { getResponseUserFriends, viewUsers } from "../../../redux/userSlice";
import Member from "../../ChannelComponents/Member/Member";
import ModalDiscoverFriends from "../../ModalDiscoverFriends/ModalDiscoverFriends";
import "./Friends.css";

function Friends() {
  const dispatch = useDispatch();
  const auth = useAuth();
  const [friends, setFriends] = useState([]);
  const responseFriends = useSelector(getResponseUserFriends);
  const token = getCookies("token");
  const [modalOpen, setModalOpen] = useState(false);
  const closeModal = () => {
    setModalOpen(false);
  };

  useEffect(() => {
    dispatch(viewUsers(token));
  }, []);

  useEffect(() => {
    console.log(responseFriends);
    setFriends(responseFriends);
  }, [responseFriends]);
  return (
    <div className="friends">
      {friends.map((item) => {
        if (item.isFollowed && auth.user.user.userName != item.userName) {
          return <Member card={item} />;
        }
      })}
      <button onClick={() => setModalOpen(true)}>Discover Friends</button>
      {modalOpen && <ModalDiscoverFriends closeModal={closeModal} />}
    </div>
  );
}

export default Friends;
