import { useEffect, useState } from "react";
import "./ModalCreateHub.css";

import { useDispatch, useSelector } from "react-redux";
import {
  deployHub,
  getError,
  getResponse,
  getResponseCreatedHub,
  getStatus,
} from "../../redux/hubSlice";
import { getCookies } from "../../Custom/useCookies";

function ModalCreateHub({ modalClose }) {
  const token = getCookies("token");
  const [hubName, setHubName] = useState("");
  const [hubDesc, setHubDesc] = useState("");
  const [privacy, setPrivacy] = useState()
  const [base64String, setBase64String] = useState()
  const dispatch = useDispatch();
  const response = useSelector(getResponseCreatedHub);

  function imageUploaded(x) {
    var file = x.target.files[0]
    console.log(file)
    var reader = new FileReader();
    console.log("next");
    reader.onload = function () {
        setBase64String(reader.result.replace("data:", "").replace(/^.+,/, ""));   
    }
    reader.readAsDataURL(file);
}

  const HandleSubmit = (e) => {
    e.preventDefault();
    dispatch(
      deployHub({ token: token, data: { name: hubName, description: hubDesc,isPrivate:privacy == 'true' ? true : false, logo: base64String  } })
    );
    modalClose();
  };
  useEffect(() => {
    console.log(response);
  }, [response]);
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
        <div className="radioBox">
          <div>
            <input
              type="radio"
              name="choice"
              value={false}
              id="Public"
              onChange={(x) => {
                setPrivacy(x.target.value);
              }}
            />
            <label for="Public">Public</label>
          </div>
          <div>
            <input
              type="radio"
              name="choice"
              value={true}
              id="Private"
              onChange={(x) => {
                setPrivacy(x.target.value);
              }}
            />
            <label for="Private">Private</label>
          </div>
        </div>
        <div className="inputFile">
          <label htmlFor="file-upload">
            <div>Choose Hub Picture</div>
            <div className="imgBtn">+</div>
          </label>
          <input id="file-upload" type="file" onChange={imageUploaded} />
        </div>
        <button type="submit">Create Hub</button>
      </form>
    </div>
  );
}

export default ModalCreateHub;
