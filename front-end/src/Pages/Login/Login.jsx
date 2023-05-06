import React, { useEffect } from "react";
import "./login.css";
import { Link, useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import { useForm } from "react-hook-form";
import { defaultUser, useAuth } from "../../Custom/useAuth";
import { BsCameraVideo } from "react-icons/bs";
import Waiting from "../../Components/Waiting/Waiting";

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
            <Link to={"/resetpassword"}>ResetPassword</Link>
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
