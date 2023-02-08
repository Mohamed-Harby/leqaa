import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import {IoIosArrowDropdown} from 'react-icons/io'
import './Dropdown.css'

function Dropdown() {
  const [showDropdown, setShowDropdown] = useState(false)
  const enableDropdown = () => {
    setShowDropdown(!showDropdown);
  }
  return (
    <div className='dropdown' onClick={() => enableDropdown()}>
      <IoIosArrowDropdown />
      <div className={showDropdown ? 'dropdown-content-show' : 'dropdown-content-hide'}>
        <Link to='/'>Link1</Link>
        <Link to='/'>Link2</Link>
        <Link to='/'>Link3</Link>
      </div>
    </div>
  )
}

export default Dropdown