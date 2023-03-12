import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./Account.css";
import {
  buyPlan,
  getPlan,
  getResponse,
  getStatus,
  viewUserProfile,
} from "../../../redux/userSlice";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";

const Account = () => {
  const [user, setUser] = useState({});
  const response = useSelector(getResponse);
  const plan = useSelector(getPlan);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
  const [selectPlan, setSelectPlan] = useState('')
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
  } = useForm();
  const onSubmitHandler = (data) => {
    setSelectPlan(data.planType)
    data.planType &&
      dispatch(buyPlan({ data: { planType: data.planType }, token: token }));
  };
  console.log(response);
  // useEffect(() => {
  //   plan.type && window.location.reload();
  // }, [plan]);
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
          <span>{user.plans?.length ? user.plans[0].type : selectPlan.length ? selectPlan : "Free"}</span> Plan
        </h3>
      </div>
    </div>
  );
};

export default Account;
