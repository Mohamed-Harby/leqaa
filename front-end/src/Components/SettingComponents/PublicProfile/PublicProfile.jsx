import React, { useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./PublicProfile.css";
import RadiusImg from "../../RadiusImg/RadiusImg";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import {
  getResponse,
  getStatus,
  setProfilePicture,
  viewUserProfile,
} from "../../../redux/userSlice";
import { AiOutlineEdit } from "react-icons/ai";
import { useNavigate } from "react-router-dom";
import Waiting from "../../Waiting/Waiting";

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

const PublicProfile = () => {
  const [base64String, setBase64String] = useState();
  const navigate = useNavigate();
  const [user, setUser] = useState({});
  const response = useSelector(getResponse);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();

  const setImage = (x) => {
    var file = x.target.files[0];
    console.log(file);
    var reader = new FileReader();
    console.log("next");
    reader.onload = function () {
      setBase64String(reader.result.replace("data:", "").replace(/^.+,/, ""));
      dispatch(setProfilePicture({ profilePicture: {profilePicture: reader.result.replace("data:", "").replace(/^.+,/, "")}, token: token }));
    };
    reader.readAsDataURL(file);
    // setRefresh(true);
  };
  useEffect(() => {
    dispatch(viewUserProfile(token));
  }, []);
  useEffect(() => {
    setUser(response);
  }, [status]);
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
  };

  // useEffect(() => {
  //   response.profilePicture != null && window.location.reload(false)
  // }, [response.profilePicture])

  return (
    <div className="publicprofile">
      <form onSubmit={handleSubmit(onSubmitHandler)}>
        <h1>Public Profile</h1>
        <div className="input">
          <label htmlFor="">Name</label>
          <input
            placeholder="Name"
            type="text"
            name="name"
            defaultValue={user?.name}
            {...register("name")}
          />
          <p>{errors.name?.message}</p>
        </div>

        <div className="input">
          <label htmlFor="">Email</label>
          <input
            type="email"
            name="email"
            placeholder="Email"
            defaultValue={user?.email}
            {...register("email")}
          />
          <p>{errors.email?.message}</p>
        </div>

        <div className="input">
          <label htmlFor="">Username</label>

          <input
            placeholder="User Name"
            type="text"
            name="username"
            defaultValue={user?.userName}
            {...register("userName")}
          />
          <p>{errors.username?.message}</p>
        </div>

        <div className="input">
          <label htmlFor="">Change Password</label>

          <input
            placeholder="Change Password"
            type="password"
            name="password"
            {...register("password")}
          />
          <p>{errors.password?.message}</p>
        </div>

        <div className="input">
          <button type="submit">Submit</button>{" "}
        </div>
      </form>

      <div className="image">
        <RadiusImg
          img={"data:image/png;base64," + user?.profilePicture}
          size={250}
        />
        <label for="inputTag">
          <span>
            <AiOutlineEdit /> Edit
          </span>
          <input id="inputTag" type="file" onChange={setImage} />
        </label>
      </div>
    </div>
  );
};

export default PublicProfile;
