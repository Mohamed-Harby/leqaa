import "./Layout.css";
import { Outlet } from "react-router-dom";
import Navbar from "../Components/Navbar/Navbar";
import Sidebar from "../Components/Sidebar/Sidebar";

export const Layout = () => {
  return (
    <>
      {/* <Navbar /> */}
      <div className="layoutContainer">
        <Sidebar />
        <div className="layoutContent">
          <Outlet />
        </div>
      </div>
    </>
  );
};
