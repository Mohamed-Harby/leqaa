import React from 'react'
import "./MeetingChat.css"
import TypingBar from "../../TypingBar/TypingBar"
import Card from '../../Card/Card'

function MeetingChat() {
  const text = [
    { msgBy: "person1", msg: "msg1" },
    { msgBy: "person2", msg: "msg2" },
    { msgBy: "person3", msg: "msg3" },
    { msgBy: "person4", msg: "msg4" },
    { msgBy: "person5", msg: "msg5" },
    { msgBy: "person6", msg: "msg6" },
  ]


  return (
    <div className='meetingChat'>
      <div className="messages">
        {text.map((item) => {
        return <Card card={item} />;
      })}
      </div>
      <TypingBar/>
    </div>
  )
}

export default MeetingChat