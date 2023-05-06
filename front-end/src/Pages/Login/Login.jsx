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

import RichLogo from "../../assets/svg/rich-logo.svg";

const schema = yup.object().shape({
  password: yup
    .string()
    .min(8)
    .max(20)
    .matches(/\d+/, "Password must have a number")
    .matches(/[a-z]+/, "Password must have a small letter")
    .matches(/[A-Z]+/, "Password must have a capital letter")
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
    console.log(auth.user);
    auth.user.isSuccess && navigate("/");
  }, [auth.user]);

  return (
    <>
      <Navbar />
      <div className="login">
        <div className="left">
          <img src={RichLogo} alt="logo" height={100} />
          {/* <h1>Video Calls and Meetings for personal Use and organizations.</h1> */}
          <p>
            Leqaa is a service for secure, high-quality video meetings and calls
            available for everyone.
          </p>
        </div>

        <div className="right">
          <div className="links">
            <Link className="active">Login</Link>
            <Link to={`/register`}>Register</Link>
          </div>

          <form onSubmit={handleSubmit(onSubmitHandler)}>
            <div className="input">
              <input
                placeholder="User Name"
                type="text"
                name="userName"
                {...register("userName")}
              />
              {errors.name || auth.user.errorMessages ? (
                <span>
                  {errors.name?.message ||
                    (auth.user.errorMessages[0]?.includes("userName") &&
                      auth.user?.errorMessages[0])}
                </span>
              ) : (
                <span></span>
              )}
            </div>
            <div className="input">
              <input
                type="password"
                id="password"
                placeholder="Password"
                {...register("password")}
              />
              {errors.password || auth.user.errorMessages ? (
                <span>
                  {errors.password?.message ||
                    (auth.user.errorMessages[0]?.includes("password") &&
                      auth.user?.errorMessages[0])}
                </span>
              ) : (
                <span></span>
              )}
            </div>
            {auth.user.errorMessages ? (
              <span>
                {auth.user.errorMessages[0]?.includes("email") &&
                  auth.user?.errorMessages[0]}
              </span>
            ) : (
              <span></span>
            )}
            <div className="reset-password">
              <span>Forgot your password?</span>
              <Link to={"/resetpassword"}>Reset it now!</Link>
            </div>
            <div className="input">
              <button type="submit">Login</button>{" "}
            </div>
          </form>
        </div>
      </div>
    </>
  );
}

export default Login;
