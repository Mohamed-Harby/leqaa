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
    .oneOf([yup.ref("password"), null])
    .required(),
});

function Register() {
  const response = useSelector(getResponse);
  const status = useSelector(getStatus);
  const error = useSelector(getError);
  const dispatch = useDispatch();
  const auth = useAuth();
  const navigate = useNavigate()

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

  useEffect(()=>{
    console.log(auth.user.isSuccess);
    auth.user.isSuccess && navigate('/');
  },[auth.user])

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
            <Link className="active">Sign Up</Link>
            <Link to={`/login`}>Login</Link>
          </div>

          <form onSubmit={handleSubmit(onSubmitHandler)}>
            <h1>Sign Up</h1>

            <div className="input">
              <input
                placeholder="Name"
                type="text"
                name="name"
                {...register("name")}
              />
              {errors.name && <p>{errors.name.message}</p>}
            </div>

            <div className="input">
              <input
                type="email"
                name="email"
                placeholder="Email"
                {...register("email")}
              />
              {errors.email && <p>{errors.email.message}</p>}
            </div>

            <div className="input">
              <input
                placeholder="User Name"
                type="text"
                name="name"
                {...register("userName")}
              />
              {errors.name && <p>{errors.name.message}</p>}
            </div>

            <div className="input">
              <select {...register("gender")}>
                <option value="">Select Gender</option>
                <option value={0}>Male</option>
                <option value={1}>Female</option>
              </select>
              {errors.confirmPassword && (
                <p>{errors.confirmPassword.message}</p>
              )}
            </div>

            <div className="input">
              <input
                placeholder="Password"
                type="password"
                name="password"
                {...register("password")}
              />
              {errors.password && <p>{errors.password.message}</p>}
            </div>

            <div className="input">
              <input
                placeholder="Confirm Password"
                type="password"
                name="confirmPassword"
                {...register("confirmPassword")}
              />
              {errors.confirmPassword && (
                <p>{errors.confirmPassword.message}</p>
              )}
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

export default Register;
