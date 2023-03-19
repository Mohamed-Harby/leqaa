import React from "react";
import "./Members.css";
import Member from "../../ChannelComponents/Member/Member";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import { getResponseGetHubUsers, viewHubUsers } from "../../../redux/hubSlice";
import { useState } from "react";
import { useEffect } from "react";

function Members({ id }) {
  const dispatch = useDispatch();
  const token = getCookies("token");
  const recent = useSelector(getResponseGetHubUsers);
  const [members, setMembers] = useState([]);
  useEffect(() => {
    dispatch(viewHubUsers({ id: id, token: token }));
  }, [id]);

  useEffect(() => {
    console.log(members);
    setMembers(recent);
  }, [recent]);

  return (
    <div className="members">
      {Array.isArray(members)
        ? members.map((item) => {
            return <Member card={item} />;
          })
        : null}
    </div>
  );
}

export default Members;
