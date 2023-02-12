import React from 'react'
import { useDispatch, useSelector } from 'react-redux'
import AdditionalSidebar from '../../Components/AdditionalSidebar/AdditionalSidebar'
import Statusbar from '../../Components/Statusbar/Statusbar'
import TypingBar from '../../Components/TypingBar/TypingBar'
import './Chat.css'

function Chat() {
  const { msgs } = useSelector((state) => state.chat);
  console.log(msgs);
  return (
    <div className='chat'>
      <AdditionalSidebar />
      <div className='chat-section'>
        <Statusbar />
        {msgs.map((msg) => {
          return(
            <div>{msg.msg}</div>
          )
        })}
        <TypingBar />
      </div>
    </div>
  )
}

export default Chat