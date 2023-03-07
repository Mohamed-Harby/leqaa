import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://localhost:5004/api/v1/Channel/";

const initialState = {
  createChannel: {},
  getChannel: {},
  status: "idle",
  error: "",
};

export const createChannel = createAsyncThunk(
  "channel/createChannel",
  async (payload) => {
    const createChannelUrl = "CreateChannel";
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

export const deleteChannel = createAsyncThunk(
  "channel/deleteChannel",
  async (payload) => {
    console.log(payload);
    const deleteChannelUrl = `DeleteChannel?id=${payload.id}`;
    try {
      const response = await axios.delete(baseUrl + deleteChannelUrl, {
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

export const getChannel = createAsyncThunk(
  "channel/getChannel",
  async (payload) => {
    const getChannelUrl = `ViewChannel?Id=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + getChannelUrl, {
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

const channelSlice = createSlice({
  name: "channel",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(createChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(createChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.createChannel = action.payload;
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
        state.getChannel = action.payload;
      })
      .addCase(getChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  },
});

export default channelSlice.reducer;
export const getResponseCreatedChannel = (state) => state.channel.createChannel;
export const getResponseGetChannel = (state) => state.channel.getChannel;
export const getErrorChannel = (state) => state.channel.error;
export const getStatusChannel = (state) => state.channel.status;
