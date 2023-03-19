import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./Account.css";
import {
  buyPlan,
  getPlan,
  getResponse,
  getStatus,
  viewUser,
  viewUserProfile,
} from "../../../redux/userSlice";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";
import { useAuth } from "../../../Custom/useAuth";

const Account = () => {
  const auth = useAuth();
  const [user, setUser] = useState({});
  const response = useSelector(getResponse);
  const plan = useSelector(getPlan);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  const [selectPlan, setSelectPlan] = useState("");
  console.log(auth.user.user);
  useEffect(() => {
    dispatch(viewUser({ token: token, username: auth.user.user.userName }));
  }, []);
  useEffect(() => {
    setUser(response);
  }, [status]);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm();
  const onSubmitHandler = (data) => {
    if (user.plans[0].type == "Premium") {
      alert("You Are Already Have Premium Plan");
    } else {
      setSelectPlan(data.planType);
      data.planType &&
        dispatch(buyPlan({ data: { planType: data.planType }, token: token }));
    }
  };
  console.log(response);
  return (
    <div className="plans">
      <form onSubmit={handleSubmit(onSubmitHandler)}>
        <h1>Billing And Plans</h1>
        <div className="input">
          <label htmlFor="planType">Plan Type</label>
          <select id="planType" {...register("planType")} name="planType">
            <option value="">Select Plan Type</option>
            <option value="Premium">Premium</option>
          </select>
        </div>
        {user[0]?.description}
        <div className="input">
          <button type="submit">Submit</button>
        </div>
      </form>
      <div>
        <h3>
          You Are{" "}
          <span>
            {user.plans?.length
              ? user.plans[0].type
              : selectPlan.length
              ? selectPlan
              : "Free"}
          </span>{" "}
          Plan
        </h3>
      </div>
    </div>
  );
};

export default Account;
