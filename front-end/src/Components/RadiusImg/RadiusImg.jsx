import React from 'react'
import "./RadiusImg.css";
import blankImg from "../../assets/blankImg.png";


function RadiusImg(props) {
  return (
    <>
      <img
        style={{ width: props.size, height: props.size }}
        className="radiusImg"
        src={props.img || blankImg}
        alt="user"
      />
    </>
  );
}

export default RadiusImg