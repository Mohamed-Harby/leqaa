import React, { useState } from "react";
import "./Statusbar.css";
import RadiusImg from "../RadiusImg/RadiusImg";
import { BsGear } from "react-icons/bs";
import { FiPhoneCall } from "react-icons/fi";
import { BsCameraVideo } from "react-icons/bs";
import Dropdown from "../../Components/Dropdown/Dropdown";

// we will need to fetch the user data and display it here in the future, img is for testing only
import profilePicture from "../../assets/badea.jpg";
import ModalCalling from "../ModalCalling/ModalCalling";
import ModalVideoCalling from "../ModalVideoCalling/ModalVideoCalling";
import { useAuth } from "../../Custom/useAuth";
import { Link, useLocation } from "react-router-dom";
import { useEffect } from "react";
import { useDispatch } from "react-redux";
import { deleteChannel } from "../../redux/channelSlice";
import { getCookies } from "../../Custom/useCookies";
import { deleteHub } from "../../redux/hubSlice";

function Statusbar({ data }) {
  console.log(data);
  const [modalOpenCalling, setModalOpenCalling] = useState(false);
  const [modalOpenVideoCalling, setModalOpenVideoCalling] = useState(false);
  const [links, setLinks] = useState([]);
  const auth = useAuth();
  const dispatch = useDispatch();
  const token = getCookies("token");
  const { pathname } = useLocation();
  const [name, setName] = useState("");
  const [desc, setDesc] = useState("");
  const path = ["/hub", "/channel"];

  useEffect(() => {
    console.log(data);
    if (pathname == "/chat") {
      setLinks([
        {
          name: "View Profile",
          to: `profile/${auth.user.user?.userName}`,
        },
        { name: "Pin Chat", to: "Link2" },
        { name: "Clear Chat", to: "Link3" },
      ]);
    } else if (pathname == "/hub") {
      setLinks([
        {
          element: "btn",
          name: "Delete Hub",
          function: () => {
            dispatch(deleteHub({ token: token, id: data.id }));
            window.location.reload(false);
          },
        },
        { element: "link", name: "Pin Chat", to: "Link2" },
        { element: "link", name: "Clear Chat", to: "Link3" },
      ]);
    } else {
      setLinks([
        {
          element: "btn",
          name: "Delete Channel",
          function: () => {
            dispatch(deleteChannel({ token: token, id: data.id }));
            window.location.reload(false);
          },
        },
        { element: "btn", name: "Pin Chat", to: "Link2" },
        { element: "btn", name: "Clear Chat", to: "Link3" },
      ]);
    }
  }, [data]);
  const modalCloseCalling = () => {
    setModalOpenCalling(false);
  };

  const modalCloseVideoCalling = () => {
    setModalOpenVideoCalling(false);
  };

  return (
    <div className="statusbar">
      <div className="left">
        <RadiusImg
          img={data?.logo ? "data:image/png;base64," + data.logo : null}
          size={40}
        />
        <div>
          <h3>{data?.name && data.name}</h3>
          <p>{data?.description && data.description}</p>
        </div>
      </div>

      <div className="right">
        {!path.includes(pathname) && (
          <FiPhoneCall
            onClick={() => {
              setModalOpenCalling(true);
            }}
          />
        )}
        {!path.includes(pathname) && (
          <BsCameraVideo
            onClick={() => {
              setModalOpenVideoCalling(true);
            }}
          />
        )}

        <Dropdown links={links} />
      </div>

      {modalOpenVideoCalling && (
        <ModalVideoCalling
          modalCloseVideoCalling={modalCloseVideoCalling}
          modalOpenVideoCalling={modalOpenVideoCalling}
        />
      )}
      {modalOpenCalling && (
        <ModalCalling modalCloseCalling={modalCloseCalling} />
      )}
    </div>
  );
}

export default Statusbar;
