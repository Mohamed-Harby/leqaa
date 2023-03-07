import React from 'react'
import RadiusImg from '../../RadiusImg/RadiusImg'
import "./ChannelCard.css"

function ChannelCard({card}) {
  return (
    <div className='channelCard'>
      <RadiusImg size="100px" />
      <h3>{card.name}</h3>
    </div>
  )
}

export default ChannelCard