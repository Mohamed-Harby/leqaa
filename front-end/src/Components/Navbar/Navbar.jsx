import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../Custom/useAuth";
import { setCookies } from "../../Custom/useCookies";
import Modal from "../Modal/Modal";
import Searchbar from "../Searchbar/Searchbar";
import "./Navbar.css";

function Navbar() {
  const auth = useAuth();
  const [modalOpen, setModalOpen] = useState(false);
  const navigate = useNavigate()
  const modalClose = () => {
    setModalOpen(false);
  };
  const logOut = () => {
    setCookies('token', '', 1)
    navigate('/login')
  }
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Leqaa</Link>
          </li>

          <li>{auth.user.user && <Searchbar />}</li>

          <li>
            {auth.user.user && (
              <button onClick={() => setModalOpen(true)}>+</button>
            )}
            {!auth.user.user && <Link to={`/login`}> Log In </Link>}
            {auth.user.user && (
              <button onClick={() => logOut()} >Log out</button>
            )}
          </li>
        </ul>
      </nav>
      {modalOpen && <Modal modalClose={modalClose} />}
    </>
  );
}

export default Navbar;
