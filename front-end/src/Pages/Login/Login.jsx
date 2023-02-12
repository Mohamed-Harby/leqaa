import React from "react";
import "./login.css";
import { Link, useLocation } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import Modal from "../../Components/Modal/Modal";

import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

import { useRef } from "react";
import { motion } from "framer-motion";
import { useMousePosition } from "../../Custom/useMousePosition";

const schema = yup.object().shape({
  email: yup
    .string()
    .email("Write your email rightly")
    .required("Email is required"),
  password: yup
    .string()
    .min(8)
    .max(20)
    .matches(/\d+/)
    .matches(/[a-z]+/)
    .matches(/[A-Z]+/)
    .required(),
});

const pathName = window.location.pathname;
let active = "";
if (pathName === "/login") {
  active = "/login";
}

function Login() {
  const { pathname } = useLocation();

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = (data) => {
    console.log({ data });
    reset();
  };

  

  return (
    <>
      <Navbar />
      <div className="login">
        
        <div className="left">
          <h1>Video Calls and Meetings for personal Use and organizations.</h1>
          <p>
            Leqaa is a service for secure, high-quality video meetings and calls
            available for everyone.
          </p>
        </div>

        <div className="right">
          <div className="links">
            <Link to={`/register`}>Sign Up</Link>
            <Link className={pathname == "/login" ? "active" : ""}>Login</Link>
          </div>

          <form onSubmit={handleSubmit(onSubmitHandler)}>
            <h1>Log In</h1>
            <div className="input">
              <input
                type="email"
                id="email"
                placeholder="Email"
                {...register("email")}
              />
              {errors.email && <p>{errors.email.message}</p>}
            </div>
            <div className="input">
              <input
                type="password"
                id="password"
                placeholder="Password"
                {...register("password")}
              />
              {errors.password && <p>{errors.password.message}</p>}
            </div>
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
