import React, { useEffect, useRef, useState } from "react";
import { motion } from "framer-motion";
import "./Carousel.css";
import Card from "../Card/Card";

const Carousel = (props) => {
  const { show } = props;
  const arr = [
    { name: "ch1", status: "live", nameOrg: "org1" },
    { name: "ch2", status: "live", nameOrg: "org1" },
    { name: "ch3", status: "live", nameOrg: "org1" },
    { name: "ch4", status: "live", nameOrg: "org1" },
    { name: "ch5", status: "live", nameOrg: "org1" },
  ];
  const [currentIndex, setCurrentIndex] = useState(0);
  const [length, setLength] = useState(arr.length);

  useEffect(() => {
    setLength(arr.length);
  }, [arr]);

  const next = () => {
    if (currentIndex < length - show) {
      setCurrentIndex((prevState) => prevState + 1);
    }
  };

  const prev = () => {
    if (currentIndex > 0) {
      setCurrentIndex((prevState) => prevState - 1);
    }
  };

  return (
    <div className="carousel">
      {currentIndex > 0 && (
        <button onClick={prev} className="left-arrow">
          {" "}
          &lt;{" "}
        </button>
      )}
      <div className="inner-carousel">
        <div
          className={`item show-${show}`}
          style={{ transform: `translateX(-${currentIndex * (100 / show)}%)` }}
        >
          {arr.map((item) => {
            return <Card card={item} />;
          })}
        </div>
      </div>
      {currentIndex < length - show && (
        <button onClick={next} className="right-arrow">
          &gt;
        </button>
      )}
    </div>
  );
};

export default Carousel;
