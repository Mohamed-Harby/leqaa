import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://localhost:5004/api/v1/Post/";

const initialState = {
  response: {},
  status: "idle",
  error: "",
};

export const addNewPost = createAsyncThunk(
  "post/addNewPost",
  async (payload) => {
    const createChannelUrl = "AddNewPost";
    try {
      const response = await axios.post(baseUrl + createChannelUrl, payload.data, {
        headers: {
          Authorization: `Bearer ${payload.token}`
        },
      });
      console.log(response.data);
      return response?.data;
    } catch (error) {
      console.log(error.response.data);
      return error.response.data;
    }
  }
);

const postSlice = createSlice({
  name: "post",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(createChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(createChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(createChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(getChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(getChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(getChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  },
});

export default postSlice.reducer;
export const getResponseChannel = (state) => state.channel.response;
export const getErrorChannel = (state) => state.channel.error;
export const getStatusChannel = (state) => state.channel.status;
