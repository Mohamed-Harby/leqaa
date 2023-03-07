import React, { useState } from "react";

import "./Modal.css";
import { useForm } from "react-hook-form";
import { AiFillCloseCircle, AiOutlineArrowLeft } from "react-icons/ai";
import useLockBodyScroll from "../../helper/use-lock-body-scroll";
import ModalCreateChannel from "../ModalCreateChannel/ModalCreateChannel";
import ModalCreateHub from "../ModalCreateHub/ModalCreateHub";

function Modal({ modalClose }) {
  useLockBodyScroll();
  const { handleSubmit, register } = useForm();
  const [currentlyOpened, setCurrentlyOpened] = useState("default")

  const onSubmit = (data) => {
    console.log(data);
    modalClose();
  };

  return (
    <div className="modal">
      <div className="modal-overlay" onClick={modalClose}></div>
      <div className="modal-content">
        <div
          className={
            currentlyOpened === "default" ? "modalNav modalNavEnd" : "modalNav"
          }
        >
          {currentlyOpened !== "default" && (
            <AiOutlineArrowLeft onClick={() => setCurrentlyOpened("default")} />
          )}
          <AiFillCloseCircle onClick={modalClose} />
        </div>

        {currentlyOpened === "default" && (
          <div className="defaultModal">
            <div className="createPlaces">
              <button>Create Instant Meeting</button>
              <button>Schedule A Meeting</button>
              <button onClick={() => setCurrentlyOpened("create_channel")}>
                Create channel
              </button>
              <button onClick={() => setCurrentlyOpened("create_hub")}>
                Create Hub
              </button>
            </div>
            <form onSubmit={handleSubmit(onSubmit)} className="box">
              <input
                type="text"
                placeholder="Meeting Code..."
                {...register("meetingcode")}
              />
              <button>Join</button>
            </form>
          </div>
        )}

        {currentlyOpened === "create_channel" && <ModalCreateChannel modalClose={modalClose} />}
        {currentlyOpened === "create_hub" && <ModalCreateHub modalClose={modalClose} />}
        
      </div>
    </div>
  );
}

export default Modal;
