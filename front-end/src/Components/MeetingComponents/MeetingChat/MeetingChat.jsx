import React from 'react'
import "./MeetingChat.css"
import TypingBar from "../../TypingBar/TypingBar"

function MeetingChat() {
  return (
    <div className='meetingChat'>
      <div className="messages">

      </div>
      <TypingBar/>
    </div>
  )
}

export default MeetingChat