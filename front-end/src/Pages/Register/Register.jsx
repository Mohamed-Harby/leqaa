import React from "react";
import "./register.css";
import { Link } from "react-router-dom";

import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

const schema = yup.object().shape({
  name: yup.string().required("Name is required"),
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
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password"), null])
    .required(),
});

function Register() {

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

      <hr color="#353535" />

      <div className="registerContainer">
        <div className="containerLeft">
          <h1>Video Calls and Meetings for personal Use and organizations.</h1>
          <p>
            Leqaa is a service for secure, high-quality video meetings and calls
            available for everyone.
          </p>

          <div className="toolbox">
            <button className="button">Create Instant Meeting</button>
            <div className="joinMeetingWithCode">
              <input
                className="registerInput"
                type="text"
                placeholder="Meeting Code..."
              />
              <button className="button">Join</button>
            </div>
          </div>
        </div>

        <form
          className="registerContainerRight"
          onSubmit={handleSubmit(onSubmitHandler)}
        >
          <h1 className="registerSecondHeader">Sign Up</h1>

          <input
            className="registerInput"
            placeholder="Email"
            type="email"
            name="email"
            {...register("email")}
          />
          {errors.email && (
            <p className="registerError">{errors.email.message}</p>
          )}

          <input
            className="registerInput"
            placeholder="User Name"
            type="text"
            name="name"
            {...register("name")}
          />
          {errors.name && (
            <p className="registerError">{errors.name.message}</p>
          )}

          <input
            className="registerInput"
            placeholder="Password"
            type="password"
            name="password"
            {...register("password")}
          />
          {errors.password && (
            <p className="registerError">{errors.password.message}</p>
          )}

          <input
            className="registerInput"
            placeholder="Confirm Password"
            type="password"
            name="confirmPassword"
            {...register("confirmPassword")}
          />
          {errors.confirmPassword && (
            <p className="registerError">{errors.confirmPassword.message}</p>
          )}

          <div className="signUpButtons">
            <Link
              to={`/login`}
              className="button secondButton"
              style={{ textDecoration: "none" }}
            >
              login
            </Link>
            <button className="button" type="submit">
              Sign Up
            </button>
          </div>
        </form>
      </div>
    </>
  );
}

export default Register;
