import {
  createBrowserRouter,
  Route,
  Navigate,
  useNavigate,
} from "react-router-dom";
import { Layout } from "../Layout/Layout";
import { getCookies } from "../Custom/useCookies";
import Chat from "../Pages/Chat/Chat";
import Home from "../Pages/Home/Home";
import Login from "../Pages/Login/Login";
import Register from "../Pages/Register/Register";
import Settings from "../Pages/Settings/Settings";
import Meeting from "../Pages/Meeting/Meeting";
import Channels from "../Pages/Channels/Channels";
import Organization from "../Pages/Organization/Organization";
import Profile from "../Pages/Profile/Profile";
import ResetPassword from "../Pages/ResetPassword/ResetPassword";
import {
  ROOT,
  LOGIN,
  REGISTER,
  SETTINGS,
  MEETING,
  CHAT,
  CHANNELS,
  ORGANIZATION,
  PROFILE,
  RESETPASSWORD,
  HUB,
  CHANNEL,
  HUBs,
  HUBS,
  CONFIRMRESETPASSWORD,
} from "./Paths";
import ConfirmResetPassword from "../Pages/ConfirmResetPassword/ConfirmResetPassword";
import { defaultUser, useAuth } from "../Custom/useAuth";

const ProtectedRoutes = ({ children }) => {
  const token = getCookies("token");
  if (!token) {
    return <Navigate to="/login" />;
  }
  return children;
};

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
      {
        path: CHANNELS,
        element: <Channels />,
      },
      {
        path: CHANNEL,
        element: <Channels />,
      },
      {
        path: HUBS,
        element: <Organization />,
      },
      {
        path: HUB,
        element: <Organization />,
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
  {
    path: RESETPASSWORD,
    element: <ResetPassword />,
  },
  {
    path: CONFIRMRESETPASSWORD,
    element: <ConfirmResetPassword />,
  },
]);
