import { createBrowserRouter, Route, Navigate } from "react-router-dom";
import { Layout } from "../Layout/Layout";
import Chat from "../Pages/Chat/Chat";
import Home from "../Pages/Home/Home";
import Login from "../Pages/Login/Login";
import Register from "../Pages/Register/Register";
import Settings from "../Pages/Settings/Settings";
import Meeting from "../Pages/Meeting/Meeting";
import { ROOT, LOGIN, REGISTER, SETTINGS, MEETING , CHAT } from "./Paths";


const auth = true

const ProtectedRoutes = ({children}) => {
    if (!auth ) {
        return <Navigate to='/login' />
    }
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