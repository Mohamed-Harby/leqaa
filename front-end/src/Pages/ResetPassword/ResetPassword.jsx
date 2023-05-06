import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useNavigate } from "react-router-dom";
import Navbar from "../../Components/Navbar/Navbar";
import Waiting from "../../Components/Waiting/Waiting";
import { useAuth } from "../../Custom/useAuth";
import "./ResetPassword.css";

const ResetPassword = () => {
  const auth = useAuth();
  const navigate = useNavigate();
  const [email, setEmail] = useState()
  const { register, handleSubmit } = useForm();

  const resetPassword = (data) => {
    setEmail(data.email)
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
      <Navbar />
      <div className="resetpassword">
        <form onSubmit={handleSubmit(resetPassword)}>
          <h1>Reset Password</h1>

          <div className="input">
            <input
              type="email"
              {...register("email")}
              placeholder="Type Your Email"
              name="email"
            />
            <div>
              {auth?.user?.errorMessages.map((errorMsg) => {
                return <>{errorMsg.includes("email") ? errorMsg : null}</>;
              })}
            </div>
          </div>

          <button type="submit">Submit</button>
        </form>
      </div>
    </>
  );
};

export default ResetPassword;
