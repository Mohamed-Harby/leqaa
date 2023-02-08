import React, { useState } from "react";
import { Link } from "react-router-dom";
import Modal from "../Modal/Modal";
import Searchbar from "../Searchbar/Searchbar";
import "./Navbar.css";

function Navbar() {
  const [search, setSearch] = useState("");
  const [modalOpen, setModalOpen] = useState(false);
  const modalClose = () => {
    setModalOpen(false);
  };
  const pathName = window.location.pathname;
  const noLoginPath = ["/register", "/login", "/settings"];

  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Leqaa</Link>
          </li>

          <li>
            <Searchbar />
          </li>

          <li>
            <button onClick={() => setModalOpen(true)}>+</button>
            {!noLoginPath.includes(pathName) ? (
              <Link
                to={`/login`}
                className="homeLoginButton"
                style={{ textDecoration: "none" }}
              >
                Log In
              </Link>
            ) : (
              ""
            )}
          </li>
        </ul>
      </nav>
      {modalOpen && <Modal modalClose={modalClose} />}
    </>
  );
}

export default Navbar;
