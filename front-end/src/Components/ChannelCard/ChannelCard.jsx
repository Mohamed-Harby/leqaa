import React from 'react'
import "./ChannelCard.css"
import RadiusImg from '../RadiusImg/RadiusImg'

function ChannelCard(props) {
  return (
    <div className='channelCard'>
      <RadiusImg size="100px" img={props.img}/>
      <h3>{props.name}</h3>
    </div>
  )
}

export default ChannelCard