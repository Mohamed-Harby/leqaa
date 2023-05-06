import React, { useEffect } from "react";
import "./register.css";
import { Link, useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import { BsCameraVideo } from "react-icons/bs";
import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { defaultUser, useAuth } from "../../Custom/useAuth";
import Waiting from "../../Components/Waiting/Waiting";

const schema = yup.object().shape({
  confirmPassword: yup
    .string()
    .oneOf([yup.ref("password"), null], "Passwords must match")
    .required(),
});

function Register() {
  const auth = useAuth();
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
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
    auth.useSignup(sendRequest);
  };

  useEffect(() => {
    auth.setUser(defaultUser)
  },[])

  useEffect(() => {
    console.log(auth.user);
    if (auth.user.isSuccess) {
      navigate("/");
    }
  }, [auth.user]);

  if (auth.loading) {
    return <Waiting />;
  }

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
                required
              />
            </div>

            <div className="input">
              <input
                type="email"
                name="email"
                placeholder="Email"
                {...register("email")}
                required
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return <>{errorMsg.includes("Email") ? errorMsg : null}</>;
                })}
              </div>
            </div>

            <div className="input">
              <input
                placeholder="User Name"
                type="text"
                name="username"
                {...register("userName")}
                required
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return <>{errorMsg.includes("Username") ? errorMsg : null}</>;
                })}
              </div>
            </div>

            <div className="input">
              <select {...register("gender")} name="gender" required>
                <option value="">Select Gender</option>
                <option value={0}>Male</option>
                <option value={1}>Female</option>
              </select>
            </div>

            <div className="input">
              <input
                placeholder="Password"
                type="password"
                name="password"
                {...register("password")}
                required
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return (
                    <>{errorMsg.includes("Passwords") ? errorMsg : null}</>
                  );
                })}
              </div>
            </div>

            <div className="input">
              <input
                placeholder="Confirm Password"
                type="password"
                name="confirmPassword"
                {...register("confirmPassword")}
                required
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
