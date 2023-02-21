import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./Settings.css";
import { getCookies } from "../../Custom/useCookies";


const schema = yup.object().shape({
  password: yup
    .string()
    .min(8)
    .max(20)
    .matches(/\d+/)
    .matches(/[a-z]+/)
    .matches(/[A-Z]+/)
    .required(),
});

function Settings() {
  const token = getCookies('token')
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = (data) => {
    console.log(data);
    const sendRequest = {email: data.email, token: token, newPassword: data.password}
    console.log(sendRequest);
    // auth.useLogin(data);
  };

  return (
    <div className="settingsPage">
      <div className="settings">
        <h1>Settings</h1>

        <form className="inputsContainer" onSubmit={handleSubmit(onSubmitHandler)}>
          <div>
            <label htmlFor="email">Email</label>
            <input type="email" id="email" placeholder="Email" {...register("email")}/>
          </div>

          <div>
            <label htmlFor="password">Password</label>
            <input type="password" id="password" placeholder="Password" {...register("password")} />
          </div>
          <div className="buttonsContainer">
            <button>Delete Account</button>
            <button type="submit">Reset Password</button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default Settings;
