import React, { useEffect } from "react";
import "./register.css";
import { Link, useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import { BsCameraVideo } from "react-icons/bs";

import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useAuth } from "../../Custom/useAuth";
import { useDispatch, useSelector } from "react-redux";
import axios from "axios";
import {
  getError,
  getResponse,
  getStatus,
  signup,
} from "../../redux/authSlice";

const schema = yup.object().shape({
  name: yup.string().required("Name is required"),
  email: yup
    .string()
    .email("Write your email rightly")
    .required("Email is required"),
  password: yup
    .string()
    .min(8)
    .matches(/\d+/)
    .matches(/[a-z]+/)
    .matches(/[A-Z]+/)
    .required(),
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password"), null], "Passwords must match")
    .required(),
});

function Register() {
  const response = useSelector(getResponse);
  const status = useSelector(getStatus);
  const error = useSelector(getError);
  const dispatch = useDispatch();
  const auth = useAuth();
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = (data) => {
    const sendRequest = {
      name: data.name,
      email: data.email,
      password: data.password,
      userName: data.userName,
      gender: Number(data.gender),
    };
    console.log(sendRequest);
    auth.useSignup(sendRequest);
    // reset();
  };

  useEffect(() => {
    console.log(auth.user.isSuccess);
    auth.user.isSuccess && navigate("/login");
  }, [auth.user]);

  return (
    <>
      <Navbar />

      <div className="register">
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
            <Link to={`/login`}>Login</Link>
            <Link className="active">Register</Link>
          </div>

          <form onSubmit={handleSubmit(onSubmitHandler)}>
            {/* <h2>Get in touch today!</h2> */}

            <div className="input">
              <input
                placeholder="Name"
                type="text"
                name="name"
                {...register("name")}
              />
              {errors.name ? (
                <span>{errors.name.message} </span>
              ) : (
                <span></span>
              )}
            </div>

            <div className="input">
              <input
                type="email"
                name="email"
                placeholder="Email"
                {...register("email")}
              />
              {errors.email || auth.user.errorMessages ? (
                <span>
                  {errors.email?.message ||
                    (auth.user.errorMessages[0]?.includes("Email") &&
                      auth.user?.errorMessages[0])}
                </span>
              ) : (
                <span></span>
              )}
            </div>

            <div className="input">
              <input
                placeholder="Username"
                type="text"
                name="username"
                {...register("userName")}
              />
              {errors.username || auth.user.errorMessages ? (
                <span>
                  {errors.name?.message ||
                    (auth.user.errorMessages[0]?.includes("Username") &&
                      auth.user?.errorMessages[0])}
                </span>
              ) : (
                <span></span>
              )}
            </div>

            <div className="input">
              <select {...register("gender")} name="gender">
                <option value="">Select Gender</option>
                <option value={0}>Male</option>
                <option value={1}>Female</option>
              </select>
              {errors.gender ? (
                <span>{errors.gender.message}</span>
              ) : (
                <span></span>
              )}
            </div>

            <div className="input">
              <input
                placeholder="Password"
                type="password"
                name="password"
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

            <div className="input">
              <input
                placeholder="Confirm Password"
                type="password"
                name="confirmPassword"
                {...register("confirmPassword")}
              />
              {errors.confirmPassword ? (
                <span>{errors.confirmPassword.message}</span>
              ) : (
                <span></span>
              )}
            </div>

            <div className="input">
              <button type="submit">Register</button>{" "}
            </div>
          </form>
        </div>
      </div>
    </>
  );
}

export default Register;
