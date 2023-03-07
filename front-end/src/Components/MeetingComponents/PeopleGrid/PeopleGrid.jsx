import React, { useEffect, useState } from "react";
import "./PeopleGrid.css";
import MeetingPersonCard from "../MeetingPersonCard/MeetingPersonCard";
import MeetingYourCard from "../MeetingYourCard/MeetingYourCard";
import google from "../../../assets/google.png";
import {peopleArr} from "./peopleArr.js"



function PeopleGrid(props) {
  let [peopleArrState, setPeopleArrState] = useState([]);

  const [activeIndex, setActiveIndex] = useState(null);
  function handleActive(index) {
    setActiveIndex(index);
  }
  
  useEffect(() => {
    let slicedArr = peopleArr.slice(0, 11);
    slicedArr = slicedArr.filter(person => person.id !== activeIndex)
    setPeopleArrState(slicedArr);
  }, [activeIndex, setPeopleArrState]);

  return (
    <>
      {activeIndex ? (
        <div className="peopleGridFocus" onClick={() => setActiveIndex(null)}>
          {activeIndex === 1 ? (
            <>
              <MeetingYourCard img={google} name={"You"} />
            </>
          ) : (
            <MeetingPersonCard
              img={peopleArr.find((person) => person.id === activeIndex).img}
              name={peopleArr.find((person) => person.id === activeIndex).name}
            />
          )}
        </div>
      ) : (
        ""
      )}

      <div className="peopleGrid" style={{ flex: props.size }}>
        {activeIndex !== 1 && (
          <MeetingYourCard
            img={google}
            name={"You"}
            index={1}
            activeIndex={activeIndex}
            handleActive={handleActive}
          />
        )}

        <PeopleComponent
          arr={peopleArrState}
          activeIndex={activeIndex}
          handleActive={handleActive}
        />
      </div>
    </>
  );
}

function PeopleComponent(props) {
  let arr = props.arr;
  return (
    <>
      {arr.map((person, index) => {
        return (
          <MeetingPersonCard
            img={person.img}
            name={person.name}
            key={person.id}
            index={person.id}
            activeIndex={props.activeIndex}
            handleActive={props.handleActive}
          />
        );
      })}
    </>
  );
}

export default PeopleGrid;
