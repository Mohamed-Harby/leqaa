import React from "react";
import "./register.css";
import { Link } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";

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
      <Navbar />
      <hr className="hrRegister" noshade />

      <div className="registerContainer">
        <div className="left">
          <h1>Video Calls and Meetings for personal Use and organizations.</h1>
          <p>
            Leqaa is a service for secure, high-quality video meetings and calls
            available for everyone.
          </p>
        </div>

        <form className="right" onSubmit={handleSubmit(onSubmitHandler)}>
          <div className="inputFields">
            <h1>Sign Up</h1>

            <input
              placeholder="Email"
              type="email"
              name="email"
              {...register("email")}
            />

            {errors.email && <p>{errors.email.message}</p>}

            <input
              placeholder="User Name"
              type="text"
              name="name"
              {...register("name")}
            />

            {errors.name && <p>{errors.name.message}</p>}

            <input
              placeholder="Password"
              type="password"
              name="password"
              {...register("password")}
            />

            {errors.password && <p>{errors.password.message}</p>}

            <input
              placeholder="Confirm Password"
              type="password"
              name="confirmPassword"
              {...register("confirmPassword")}
            />

            {errors.confirmPassword && <p>{errors.confirmPassword.message}</p>}
          </div>

          <div className="buttonsContainer">
            <Link to={`/login`}>
              login
            </Link>
            <button type="submit">Sign Up</button>
          </div>
        </form>
      </div>
    </>
  );
}

export default Register;
