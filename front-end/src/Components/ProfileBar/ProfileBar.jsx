import React from 'react'
import RadiusImg from '../RadiusImg/RadiusImg'
import './ProfileBar.css'
import {AiOutlineMessage} from 'react-icons/ai'
import {FiSettings} from 'react-icons/fi'

function ProfileBar() {
  return (
    <div className='profilebar'>
      <div className='left'>
          <RadiusImg size={40} />
          <span>Person Name</span>
      </div>
      <div className='right'>
          <AiOutlineMessage />
          <FiSettings />
      </div>
    </div>
  )
}

export default ProfileBar