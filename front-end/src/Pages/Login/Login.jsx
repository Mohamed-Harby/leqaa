import React, { useEffect } from "react";
import "./login.css";
import { Link, Navigate, useLocation, useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useAuth } from "../../Custom/useAuth";
import { useDispatch, useSelector } from "react-redux";
import {
  getError,
  getResponse,
  getStatus,
  getUser,
} from "../../redux/authSlice";
import useCookies from "react-cookie/cjs/useCookies";
import { getCookies } from "../../Custom/useCookies";
import { BsCameraVideo } from "react-icons/bs";

const schema = yup.object().shape({
  password: yup
    .string()
    .min(8)
    .max(20)
    .matches(/\d+/)
    .matches(/[a-z]+/)
    .matches(/[A-Z]+/)
    .required(),
});

function Login() {
  const { pathname } = useLocation();
  const dispatch = useDispatch();
  const auth = useAuth();
  const [cookies, setCookie] = useCookies(["token"]);
  const status = useSelector(getStatus);
  const error = useSelector(getError);
  const navigate = useNavigate();
  const token = getCookies("token");

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = (data) => {
    auth.useLogin(data);
  };

  useEffect(() => {
    console.log(auth.user.isSuccess);
    auth.user.isSuccess && navigate("/");
  }, [auth.user]);

  return (
    <>
      <Navbar />
      <div className="login">
        <div className="left">
          <h1>
            <BsCameraVideo />
            Video Calls and Meetings for personal Use and organizations.
          </h1>
          <p>
            Leqaa is a service for secure, high-quality video meetings and calls
            available for everyone.
          </p>
        </div>

        <div className="right">
          <div className="links">
            <Link to={`/register`}>Sign Up</Link>
            <Link className="active">Login</Link>
          </div>

          <form onSubmit={handleSubmit(onSubmitHandler)}>
            <h1>Log In</h1>
            <div className="input">
              <input
                placeholder="User Name"
                type="text"
                name="name"
                {...register("userName")}
              />
              {(errors.name || auth.user.errorMessages) && (
                <p>
                  {errors.name?.message ||
                    (auth.user.errorMessages[0]?.includes("username") &&
                      auth.user?.errorMessages[0])}
                </p>
              )}
            </div>
            <div className="input">
              <input
                type="password"
                id="password"
                placeholder="Password"
                {...register("password")}
              />
              {(errors.password || auth.user.errorMessages) && (
                <p>
                  {errors.password?.message ||
                    (auth.user.errorMessages[0]?.includes("password") &&
                      auth.user?.errorMessages[0])}
                </p>
              )}
            </div>
            {auth.user.errorMessages && (
              <p>
                {auth.user.errorMessages[0]?.includes("email") &&
                  auth.user?.errorMessages[0]}
              </p>
            )}
            <Link to={"/resetpassword"}>ResetPassword</Link>
            <div className="input">
              <button type="submit">Submit</button>{" "}
            </div>
          </form>
        </div>
      </div>
    </>
  );
}

export default Login;
