import React from 'react'
import "./PeopleGrid.css"
import MeetingPersonCard from '../MeetingPersonCard/MeetingPersonCard';
import profilePicture from "../../../assets/badea.jpg";







function PeopleGrid(props) {
  let peopleArr = [
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
    {img: profilePicture, name: "Person Name"},
  ]

  let peopleGridArr = peopleArr.slice(0, props.numberOfPeopleDisplayed)

  return (
    <div className="peopleGrid" style={{flex:props.size}}>
      {peopleGridArr.map((person, index) => {
        return <MeetingPersonCard img={person.img} name={person.name} key={index}/>;
      }) }

    </div>
  );
}

export default PeopleGrid