import React from "react";
import "./login.css";
import { Link } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import Modal from "../../Components/Modal/Modal";

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
      <Navbar />
      <hr className="hrLogin" noshade />

      <div className="loginContainer">
        <div className="left">
          <div className="container">
            <h1>
              Video Calls and Meetings for personal Use and organizations.
            </h1>
            <p>
              Leqaa is a service for secure, high-quality video meetings and
              calls available for everyone.
            </p>
          </div>
        </div>

        <form className="right" onSubmit={handleSubmit(onSubmitHandler)}>
          <div className="inputFields">
            <h1>Log In</h1>

            <input type="email" placeholder="Email" {...register("email")} />
            {errors.email && <p>{errors.email.message}</p>}
            <input
              type="password"
              placeholder="Password"
              {...register("password")}
            />
            {errors.password && <p>{errors.password.message}</p>}
          </div>

        <div className="buttonsContainer">
            <Link to={`/register`}>Sign Up</Link>
            <button type="submit">Login</button>
          </div>
        </form>
      </div>
    </>
  );
}

export default Login;
