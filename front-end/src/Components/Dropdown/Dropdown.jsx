import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import {IoIosArrowDropdown} from 'react-icons/io'
import './Dropdown.css'

function Dropdown(props) {
  const [showDropdown, setShowDropdown] = useState(false)
  const {links} = props
  const enableDropdown = () => {
    setShowDropdown(!showDropdown);
  }
  return (
    <div className='dropdown' onClick={() => enableDropdown()}>
      <IoIosArrowDropdown />
      <div className={showDropdown ? 'dropdown-content-show' : 'dropdown-content-hide'}>
        {links.map((link)=>{
          return(
            <Link to={`/${link}`}>{link}</Link>
          )
        })}
      </div>
    </div>
  )
}

export default Dropdown