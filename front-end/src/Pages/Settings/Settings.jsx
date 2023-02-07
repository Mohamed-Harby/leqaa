import React from "react";
import "./Settings.css";
import Navbar from "../../Components/Navbar/Navbar";
import Sidebar from "../../Components/Sidebar/Sidebar";

function Settings() {
  return (
    <>
      <Navbar />
      <div className="settingsPage">
        <Sidebar />
        <main>
          <div className="settings">
            <h1>Settings</h1>

            <div className="inputsContainer">
              <div>
                <label htmlFor="email">Email</label>
                <input
                  type="email"
                  name="email"
                  placeholder="email@gmail.com"
                />
              </div>
              <div>
                <label htmlFor="name">User Name</label>
                <input type="text" name="name" placeholder="Person Name" />
              </div>
              <div>
                <label htmlFor="password">Password</label>
                <input
                  type="password"
                  name="password"
                  placeholder="name#name"
                />
              </div>
            </div>

            <div className="buttonsContainer">
              <button>Delete Account</button>
              <button>Edit</button>
            </div>
          </div>
        </main>
      </div>
    </>
  );
}

export default Settings;
