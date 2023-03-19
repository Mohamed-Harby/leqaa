import React from "react";
import { useState } from "react";
import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getCookies, setCookies } from "../../../Custom/useCookies";
import {
  getResponseViewRecentActivitiesChannel,
  viewRecentActivities,
} from "../../../redux/channelSlice";
import CardJoinMeeting from "../../HomeComponents/Cards/Meeting/CardJoinMeeting";
import Post from "../../HomeComponents/Cards/Post/Post";
import "./Recent.css";

const Recent = ({ id }) => {
  const dispatch = useDispatch();
  const token = getCookies("token");
  const recent = useSelector(getResponseViewRecentActivitiesChannel);
  const [viewRecent, setViewRecent] = useState();
  useEffect(() => {
    dispatch(viewRecentActivities({ id: id, token: token }));
  }, [id]);

  useEffect(() => {
    console.log(recent);
    setViewRecent(recent);
  }, [recent]);

  return (
    <div className="recent">
      {Array.isArray(viewRecent)
        ? viewRecent?.map((item) => {
            const key = Object.keys(item);
            if (key[0] == "title") {
              return <Post card={item} />;
            } else {
              return <CardJoinMeeting card={item} />;
            }
          })
        : null}
    </div>
  );
};

export default Recent;
