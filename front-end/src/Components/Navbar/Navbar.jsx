import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../../Custom/useAuth";
import Modal from "../Modal/Modal";
import Searchbar from "../Searchbar/Searchbar";
import "./Navbar.css";

function Navbar() {
  const auth = useAuth()
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
            <Searchbar />
          </li>

          <li>
            <button onClick={() => setModalOpen(true)}>+</button>
            {!auth.user.isSuccess && <Link to={`/login`}> Log In </Link>}
          </li>

        </ul>
      </nav>
      {modalOpen && <Modal modalClose={modalClose} />}
    </>
  );
}

export default Navbar;
