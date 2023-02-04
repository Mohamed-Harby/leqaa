import React from 'react'
import "./login.css"
import { Link } from "react-router-dom";

import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

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

function Login() {
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
      <Link
        to={`/`}
        className="logo"
        style={{ textDecoration: "none" }}
      >
        Leqaa
      </Link>
      <hr color="#353535" noshade />

      <div className="loginContainer">
        <div className="loginContainerLeft">
          <div className="headers">
            <h1 className="mainHeader">
              Video Calls and Meetings for personal Use and organizations.
            </h1>
            <div className="subHeader">
              Leqaa is a service for secure, high-quality video meetings and
              calls available for everyone.
            </div>
          </div>

          <div className="loginToolbox">
            <button className="button">Create Instant Meeting</button>
            <div className="joinMeetingWithCode">
              <input
                className="loginInput"
                type="text"
                placeholder="Meeting Code..."
              />
              <button className="button">Join</button>
            </div>
          </div>
        </div>

        <form
          className="loginContainerRight"
          onSubmit={handleSubmit(onSubmitHandler)}
        >
          <div className="loginInputFields">
            <h1 className="loginText">Log In</h1>
            <input
              className="loginInput"
              type="email"
              placeholder="Email"
              {...register("email")}
            />
            {errors.email && (
              <p className="loginError">{errors.email.message}</p>
            )}
            <input
              className="loginInput"
              type="password"
              placeholder="Password"
              {...register("password")}
            />
            {errors.password && (
              <p className="loginError">{errors.password.message}</p>
            )}
          </div>

          <div className="loginButtons">
            <Link
              to={`/register`}
              className="button secondButton"
              style={{ textDecoration: "none" }}
            >
              Sign Up
            </Link>
            <button className="button" type="submit">
              Login
            </button>
          </div>
        </form>
      </div>
    </>
  );
}

export default Login