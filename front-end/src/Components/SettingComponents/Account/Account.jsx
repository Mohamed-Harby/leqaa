import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./Account.css";
import {
  buyPlan,
  getResponse,
  getStatus,
  viewUserProfile,
} from "../../../redux/userSlice";
import { useDispatch, useSelector } from "react-redux";
import { getCookies } from "../../../Custom/useCookies";

const Account = () => {

  const [user, setUser] = useState({});
  const response = useSelector(getResponse);
  const status = useSelector(getStatus);
  const token = getCookies("token");
  const dispatch = useDispatch();
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
    data.planType && dispatch(buyPlan({ data: { planType: data.planType }, token: token }));
  };
  return (
    <div className="plans">
      <form onSubmit={handleSubmit(onSubmitHandler)}>
        <h1>Billing And Plans</h1>
        <div className="input">
          <label htmlFor="planType">Plan Type</label>
          <select id="planType" {...register("planType")} name="planType">
            <option value="">Select Plan Type</option>
            <option value="premium">Premium</option>
          </select>
        </div>
        {user[0]?.description}
        <div className="input">
          <button type="submit">Submit</button>
        </div>
      </form>
      <div>
        <h3>You Are {user.plans?.length ? user.plans[0].type : "Free"} Plan</h3>
      </div>
    </div>
  );
};

export default Account;
