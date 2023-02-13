import React from 'react'
import "./MeetingChat.css"
import TypingBar from "../../TypingBar/TypingBar"

function MeetingChat() {
  return (
    <div className='meetingChat'>
      <div className="messages">
        Meeting Chat
      </div>
      <TypingBar/>
    </div>
  )
}

export default MeetingChat