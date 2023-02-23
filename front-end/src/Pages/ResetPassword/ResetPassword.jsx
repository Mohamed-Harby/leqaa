import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import Waiting from "../../Components/Waiting/Waiting";
import { useAuth } from "../../Custom/useAuth";
import { getStatus } from "../../redux/authSlice";
import "./ResetPassword.css";

const ResetPassword = () => {
  const [confirmReset, setConfirmReset] = useState(false);
  const [email, setEmail] = useState("");
  const navigate = useNavigate();
  const status = useSelector(getStatus);
  const {
    reset,
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();
  const auth = useAuth();
  const resetPassword = (data) => {
    auth.useSendResetPasswordEmail(data);
    setEmail(data.email);
    reset();
  };

  useEffect(() => {
    console.log(status);
    if (auth.user.isSuccess) {
      setConfirmReset(true);
    } else {
      setConfirmReset(false);
    }
  }, [auth.user.isSuccess]);

  const confirmResetPassword = (data) => {
    const sendRequest = {
      email: email,
      token: data.token,
      newPassword: data.password,
    };
    auth.useResetPassword(sendRequest);
    navigate("/");
    console.log(sendRequest);
  };

  return (
    <>
      <Navbar />
      {status != "loading" ? (
        <div className="resetpassword">
          {confirmReset ? (
            <form onSubmit={handleSubmit(confirmResetPassword)}>
              <h1>Confirm Reset Password</h1>

              <div className="input">
                <textarea
                  type="text"
                  {...register("token")}
                  placeholder="Type Your Token"
                  name="token"
                />
                {auth.user.errorMessages && <p>{auth.user.errorMessages[0]}</p>}
              </div>

              <div className="input">
                <input
                  type="password"
                  {...register("password")}
                  placeholder="Type Your Password"
                  name="password"
                />
                {auth.user.errorMessages && <p>{auth.user.errorMessages[0]}</p>}
              </div>

              <button type="submit">Submit</button>
            </form>
          ) : (
            <form onSubmit={handleSubmit(resetPassword)}>
              <h1>Reset Password</h1>

              <div className="input">
                <input
                  type="email"
                  {...register("email")}
                  placeholder="Type Your Email"
                  name="email"
                />
                {auth.user.errorMessages && <p>{auth.user.errorMessages[0]}</p>}
              </div>

              <button type="submit">Submit</button>
            </form>
          )}
        </div>
      ) : (
        <Waiting />
      )}
    </>
  );
};

export default ResetPassword;
