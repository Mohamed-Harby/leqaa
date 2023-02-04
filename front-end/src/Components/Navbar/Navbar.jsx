import React, { useState } from "react";
import { Link } from "react-router-dom";
import Modal from "../Modal/Modal";
import "./Navbar.css";

function Navbar() {
  const [search, setSearch] = useState("");
  const [modalOpen, setModalOpen] = useState(false);
  const modalClose = () => {
    setModalOpen(false);
  };

  return (
    <>
      <nav>
        <ul>

          <li>
            <Link to="/">Leqaa</Link>
          </li>

          <li>
            <input
              type="search"
              placeholder="Search"
              onChange={(x) => setSearch(x.target.value)}
            />
          </li>

          <li>
            <button onClick={() => setModalOpen(true)}>+</button>
            {/* <button>Log In</button> */}
            <Link
              to={`/login`}
              className="homeLoginButton"
              style={{ textDecoration: "none" }}
            >
              Log In
            </Link>


          </li>
          
        </ul>
      </nav>
      {modalOpen && <Modal modalClose={modalClose} />}
    </>
  );
}

export default Navbar;
