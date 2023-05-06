import React, { useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
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
import { useAuth } from "../../../Custom/useAuth";

const PublicProfile = () => {
  const auth = useAuth();
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
      dispatch(
        setProfilePicture({
          profilePicture: {
            profilePicture: reader.result
              .replace("data:", "")
              .replace(/^.+,/, ""),
          },
          token: token,
        })
      );
    };
    reader.readAsDataURL(file);
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
  } = useForm();

  const onSubmitHandler = (data) => {
    console.log(data);
  };

  const handleReset = () => {
    console.log(user.email);
    auth.useSendResetPasswordEmail({ email: user.email });
  };

  useEffect(() => {
    if (auth.user.isReset) {
      navigate(`/resetpassword/${user.email}`);
    }
  }, [auth.user]);

  if (auth.loading) {
    return <Waiting />;
  }

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

        <button className="input" onClick={() => handleReset()}>
          Change Password
        </button>

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
