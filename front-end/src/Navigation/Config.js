import { createBrowserRouter, Route, Navigate, useNavigate } from "react-router-dom";
import { Layout } from "../Layout/Layout";
import Chat from "../Pages/Chat/Chat";
import Home from "../Pages/Home/Home";
import Login from "../Pages/Login/Login";
import Register from "../Pages/Register/Register";
import Settings from "../Pages/Settings/Settings";
import Meeting from "../Pages/Meeting/Meeting";
import { ROOT, LOGIN, REGISTER, SETTINGS, MEETING, CHAT, PROFILE } from "./Paths";
import { useAuth } from "../Custom/useAuth";
import { useEffect } from "react";
import { getStatus, getUser } from "../redux/authSlice";
import { useDispatch, useSelector } from "react-redux";
import useCookies from "react-cookie/cjs/useCookies";
import { getCookies } from "../Custom/useCookies";
import axios from "axios";
import Profile from "../Pages/Profile/Profile";


const ProtectedRoutes = ({ children }) => {
  const token = getCookies('token')
  const navigate = useNavigate()
  const auth = useAuth()
  useEffect(() => {
    axios.get('http://localhost:5002/api/v1/Authentication/GetUser', {
      headers: {
        Authorization: `Bearer ${token}`
      }
    }).then((res) => {
      console.log(res);
      auth.setUser(res.data)
    }).catch((error)=>{
      console.log(error);
      navigate('/login')
    })
  }, [children])
  return children
}

export const RouterConfig = createBrowserRouter([
  {
    path: ROOT,
    element: (
      <ProtectedRoutes>
        <Layout />
      </ProtectedRoutes>
    ),
    children: [
      {
        path: ROOT,
        element: <Home />,
      },
      {
        path: SETTINGS,
        element: <Settings />,
      },
      {
        path: MEETING,
        element: <Meeting />,
      },
      {
        path: CHAT,
        element: <Chat />,
      },
      {
        path: PROFILE,
        element: <Profile />,
      },
    ],
  },
  {
    path: LOGIN,
    element: <Login />,
  },
  {
    path: REGISTER,
    element: <Register />,
  },
]);