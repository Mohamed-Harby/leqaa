import React from "react";
import { Announcement } from "../Announcement/Announcement";
import "./Announcements.css";
import { useDispatch, useSelector } from "react-redux";
import { getHubAnnoucements, getResponseGethubAnnoucements, getResponsehubAnnoucement } from "../../../redux/announcementSlice";
import { useEffect } from "react";
import { getCookies } from "../../../Custom/useCookies";
import { useParams } from "react-router-dom";

const Announcements = () => {
  const hubsAnnouncements = useSelector(getResponseGethubAnnoucements)
  const hubsAnnouncement = useSelector(getResponsehubAnnoucement)
  const dispatch = useDispatch()
  const token = getCookies('token')
  const {id} = useParams()
  useEffect(() => {
    dispatch(getHubAnnoucements({token: token, id:id}))
  }, [hubsAnnouncement])
  return (
    <div className="announcements">
      {hubsAnnouncements?.map((item) => {
        return <Announcement card={item} />;
      })}
    </div>
  );
};

export default Announcements;
