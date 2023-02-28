import React, { useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./Settings.css";
import { getCookies } from "../../Custom/useCookies";
import PublicProfile from "../../Components/SettingComponents/PublicProfile/PublicProfile";
import Account from "../../Components/SettingComponents/Account/Account";



function Settings() {
  const token = getCookies("token");
  const publicProfile = useRef(null);
  const billingAndPlans = useRef(null);
  const [components, setComponents] = useState("Public Profile");


  // const onClick = (event) => {
  //   event.currentTarget.classList.toggle('active');
  // }

  return (
    <div className="settingsPage">
      <div className="sidebar">
        <ul>
          <li>
            <button ref={publicProfile} value="Public Profile" onClick={() => setComponents(publicProfile.current.value)}>Public Profile</button>
          </li>
          <li>
            <button ref={billingAndPlans} value="Billing And Plans" onClick={() => setComponents(billingAndPlans.current.value)}>Billing And Plans</button>
          </li>
        </ul>
      </div>
      <div className="settings">
        {components == "Public Profile" && <PublicProfile />}
        {components == "Billing And Plans" && <Account />}
      </div>
    </div>
  );
}

export default Settings;
