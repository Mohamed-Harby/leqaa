import React from 'react'
import "./TypingBar.css"
import {AiOutlineSend} from "react-icons/ai"

function TypingBar() {
  return (
    <div className='typingBar'>
      <input type="text" placeholder='chat'/>
      <button type="send">
        <AiOutlineSend/>
      </button>
    </div>
  )
}

export default TypingBar