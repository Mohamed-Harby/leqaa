import React from 'react'
import RadiusImg from '../../../RadiusImg/RadiusImg'
import './CardJoinMeetingCarousel.css'

const CardJoinMeetingCarousel = ({card}) => {
  return (
    <div className='cardJoinMeetingCarousel'>
        <RadiusImg size={50} />
        <div className="content">
            <div>{card?.meetingName}</div>
            <div>{card?.existingNumbers}</div>
            <button>Join</button>
        </div>

    </div>
  )
}

export default CardJoinMeetingCarousel