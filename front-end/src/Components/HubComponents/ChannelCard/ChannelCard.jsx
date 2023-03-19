import React from 'react'
import { useDispatch } from 'react-redux'
import { useNavigate } from 'react-router-dom'
import { getCookies } from '../../../Custom/useCookies'
import { getChannel } from '../../../redux/channelSlice'
import RadiusImg from '../../RadiusImg/RadiusImg'
import "./ChannelCard.css"

function ChannelCard({card}) {
  const dispatch = useDispatch()
  const token = getCookies('token')
  const navigate = useNavigate()
  const handleClick = () => {
    dispatch(getChannel({id: card.id, token: token}))
    navigate(`/channel/${card.id}`)
  }
  return (
    <div onClick={() => handleClick()} className='channelCard'>
      <RadiusImg size="100px" />
      <h3>{card.name}</h3>
    </div>
  )
}

export default ChannelCard