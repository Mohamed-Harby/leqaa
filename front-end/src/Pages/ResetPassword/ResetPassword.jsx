import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import Waiting from "../../Components/Waiting/Waiting";
import { useAuth } from "../../Custom/useAuth";
import "./ResetPassword.css";
import banner from "../../assets/svg/reset-password.svg";
import LogoWhite from "../../assets/svg/logo-white.svg";

const ResetPassword = () => {
  const auth = useAuth();
  const navigate = useNavigate();
  const [email, setEmail] = useState();
  const { register, handleSubmit } = useForm();

  const resetPassword = (data) => {
    setEmail(data.email);
    auth.useSendResetPasswordEmail(data);
  };

  useEffect(() => {
    if (auth.user.isReset) {
      navigate(`/resetpassword/${email}`);
    }
  }, [auth.user]);

  if (auth.loading) {
    return <Waiting />;
  }

  return (
    <>
      {/* <Navbar /> */}
      <div className="reset-password">
        <div className="left">
          <div
            className="banner-heading"
            onClick={() => {
              navigate("/");
            }}
          >
            <img src={LogoWhite} width={50} height={50} /> <h1>leqaa</h1>
          </div>
          <img src={banner} className="banner-image"></img>
          <div className="banner-footer-text">Join and connect globally!</div>
        </div>
        <div className="right">
          <div className="heading">
            <h1>Recover your account!</h1>
          </div>
          <form onSubmit={handleSubmit(resetPassword)}>
            <div className="input">
              <input
                type="email"
                {...register("email")}
                placeholder="Type your email"
                name="email"
              />
              <div>
                {auth?.user?.errorMessages.map((errorMsg) => {
                  return <>{errorMsg.includes("email") ? errorMsg : null}</>;
                })}
              </div>
            </div>
            <div className="input">
              <button type="submit">Submit</button>
            </div>
          </form>
          <button
            className="naviagte-button"
            onClick={() => {
              navigate("/login");
            }}
          >
            Return to login page
          </button>
        </div>
      </div>
    </>
  );
};

export default ResetPassword;
