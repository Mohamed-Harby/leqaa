import React from "react";
import "./Modal.css";
import { useForm } from "react-hook-form";
import { AiFillCloseCircle } from "react-icons/ai";
import useLockBodyScroll from "../../helper/use-lock-body-scroll";

function Modal({ modalClose }) {
  useLockBodyScroll();
  const { handleSubmit, register } = useForm();
  const onSubmit = (data) => {
    console.log(data);
    modalClose();
  };
  return (
    <div className="modal">
      <div className="modal-overlay" onClick={modalClose}></div>
      <div className="modal-content">
        <AiFillCloseCircle onClick={modalClose} />
        <button>Create Instant Meeting</button>
        <button>Schedule A Meeting</button>
        <form onSubmit={handleSubmit(onSubmit)} className="box">
          <input
            type="text"
            placeholder="Meeting Code..."
            {...register("meetingcode")}
          />
          <button>Join</button>
        </form>
      </div>
    </div>
  );
}

export default Modal;
