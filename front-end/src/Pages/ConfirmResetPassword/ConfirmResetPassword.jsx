import React from "react";
import "./ConfirmResetPassword.css";
import { useNavigate, useParams } from "react-router-dom";
import { useAuth } from "../../Custom/useAuth";
import { useForm } from "react-hook-form";
import { useEffect } from "react";
import Waiting from "../../Components/Waiting/Waiting";
import Navbar from "../../Components/Navbar/Navbar";

function ConfirmResetPassword() {
  const { email } = useParams();
  const auth = useAuth();
  const navigate = useNavigate();
  const { register, handleSubmit } = useForm();
  console.log(auth.user);

  const confirmResetPassword = (data) => {
    const sendRequest = {
      email: email,
      token: data.token,
      newPassword: data.password,
    };
    auth.useResetPassword(sendRequest);
  };

  useEffect(() => {
    if (auth.user.isConfirmedReset) {
      navigate("/login");
    }
  }, [auth.user]);

  if (auth.loading) {
    return <Waiting />;
  }
  return (
    <>
      <Navbar />
      <div className="resetpassword">
        <form onSubmit={handleSubmit(confirmResetPassword)}>
          <h1>Confirm Reset Password</h1>

          <div className="input">
            <textarea
              type="text"
              {...register("token")}
              placeholder="Type Your Token"
              name="token"
            />
            <div>
              {auth?.user?.errorMessages.map((errorMsg) => {
                return <>{errorMsg.includes("token") ? errorMsg : null}</>;
              })}
            </div>
          </div>

          <div className="input">
            <input
              type="password"
              {...register("password")}
              placeholder="Type Your Password"
              name="password"
            />
            <div>
              {auth?.user?.errorMessages.map((errorMsg) => {
                return <>{errorMsg.includes("Passwords") ? errorMsg : null}</>;
              })}
            </div>
          </div>

          <button type="submit">Submit</button>
        </form>
      </div>
    </>
  );
}

export default ConfirmResetPassword;
