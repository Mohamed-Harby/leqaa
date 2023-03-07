import React, { useState } from "react";
import { Link } from "react-router-dom";
import { BsGear } from "react-icons/bs";
import "./Dropdown.css";

function Dropdown(props) {
  const [showDropdown, setShowDropdown] = useState(false);
  const { links } = props;
  const enableDropdown = () => {
    setShowDropdown(!showDropdown);
  };
  return (
    <div className="dropdown" onClick={() => enableDropdown()}>
      <BsGear />
      <div
        className={
          showDropdown ? "dropdown-content-show" : "dropdown-content-hide"
        }
      >
        {links.map((link) => {
          return link.element == "link" ? (
            <Link to={`/${link.to}`}>{link.name}</Link>
          ) : (
            <button onClick={link.function}>{link.name}</button>
          );
        })}
      </div>
    </div>
  );
}

export default Dropdown;
