import { useState } from 'react';
import "./ModalCreateHub.css"

import { useDispatch } from 'react-redux';
import {
  deployHub,
  getResponse,
  getError,
  getStatus,
} from "../../redux/hubSlice";
import { getCookies } from "../../Custom/useCookies";


function ModalCreateHub() {
  const token = getCookies("token");
  const [hubName, setHubName] = useState("");
  const [hubDesc, setHubDesc] = useState("");
  const dispatch = useDispatch();

  const HandleSubmit = (e) => {
    e.preventDefault();
    dispatch(
      deployHub({
        token: token,
        name: hubName,
        description: hubDesc,
      })
    );
    console.log(getResponse);
  };

  return (
    <div className="modalCreateHub">
      <h1>Create Hub</h1>
      <form onSubmit={HandleSubmit} className="box">
        <input
          type="text"
          placeholder="Hub Name"
          name="Hub_name"
          onChange={(e) => setHubName(e.target.value)}
        />
        <input
          type="text"
          placeholder="Description"
          name="hub_desc"
          onChange={(e) => setHubDesc(e.target.value)}
        />
        <button type="submit">Create Hub</button>
      </form>
    </div>
  );
}

export default ModalCreateHub