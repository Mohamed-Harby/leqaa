import React from 'react'
import AdditionalSidebar from '../../Components/AdditionalSidebar/AdditionalSidebar'
import Statusbar from '../../Components/Statusbar/Statusbar'
import TypingBar from '../../Components/TypingBar/TypingBar'
import './Chat.css'

function Chat() {
  return (
    <div className='chat'>
      <AdditionalSidebar />
      <div className='chat-section'>
        <Statusbar />
        <TypingBar />
      </div>
    </div>
  )
}

export default Chat