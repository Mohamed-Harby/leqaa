import React, { useEffect } from "react";
import Card from "../../Card/Card";
import CardJoinMeeting from "../Cards/Meeting/CardJoinMeeting";
import Post from "../Cards/Post/Post";
import "./RecentActivities.css";

import { useDispatch, useSelector } from "react-redux";
import {
  viewRecentActivitiesHome,
  getResponseRecentActivities,
} from "../../../redux/homeSlice";

import { getCookies } from "../../../Custom/useCookies";

function RecentActivities() {
  const dispatch = useDispatch();
  const recentActivities = useSelector(getResponseRecentActivities);
  const token = getCookies("token");

  useEffect(() => {
    dispatch(viewRecentActivitiesHome({ token: token }));
  }, [dispatch, token]);

  return (
    <div className="recentactivities">
      {recentActivities.map((activity, index) => {
        if (activity.type == "post") {
          return <Post key={index} post={activity} />;
        } else {
          // return <CardJoinMeeting key={index} meeting={item} />;
        }
      })}
    </div>
  );
}

export default RecentActivities;
