import React, { useEffect } from "react";
import "./login.css";
import { Link, useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import { useForm } from "react-hook-form";
import { defaultUser, useAuth } from "../../Custom/useAuth";
import { BsCameraVideo } from "react-icons/bs";
import Waiting from "../../Components/Waiting/Waiting";
import banner from "../../assets/svg/calling-banner.svg";
import LogoWhite from "../../assets/svg/logo-white.svg";

function Login() {
  const auth = useAuth();
  const navigate = useNavigate();
  const { register, handleSubmit } = useForm();
  console.log(auth.user);

  const onSubmitHandler = (data) => {
    auth.useLogin(data);
  };

  useEffect(() => {
    auth.setUser(defaultUser);
  }, []);

  useEffect(() => {
    if (auth.user.token) {
      navigate("/");
    }
  }, [auth.user]);

  if (auth.loading) {
    return <Waiting />;
  }

  return (
    <>
      {/* <Navbar /> */}
      <div className="login">
        <div className="left">
          <div className="banner-heading">
            <img src={LogoWhite} width={50} height={50} /> <h1>leqaa</h1>
          </div>
          <img src={banner} className="banner-image"></img>
          <div className="banner-footer-text">Join and connect globally!</div>
        </div>

        <div className="right">
          <div className="heading">
            <h1>Welcome back!</h1>
          </div>
          <form onSubmit={handleSubmit(onSubmitHandler)}>
            <div className="input">
              <input
                placeholder="Username"
                type="text"
                name="userName"
                {...register("userName")}
                required
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return <>{errorMsg.includes("username") ? errorMsg : null}</>;
                })}
              </div>
            </div>
            <div className="input">
              <input
                type="password"
                id="password"
                placeholder="Password"
                {...register("password")}
                required
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return <>{errorMsg.includes("password") ? errorMsg : null}</>;
                })}
              </div>
            </div>
            <div>
              {auth?.user?.errorMessages.map((errorMsg) => {
                return <>{errorMsg.includes("email") ? errorMsg : null}</>;
              })}
            </div>
            <span className="action-span">
              <Link to={"/resetpassword"}>Forgot password?</Link>
            </span>
            {/* <span className="action-span">
                Not joined yet? <Link to={`/register`}>register now!</Link>
              </span> */}
            <div className="input">
              <button type="submit">Login</button>
            </div>
          </form>
          <button
            className="naviagte-button"
            onClick={() => {
              navigate("/register");
            }}
          >
            Create an account
          </button>
        </div>
      </div>
    </>
  );
}

export default Login;
