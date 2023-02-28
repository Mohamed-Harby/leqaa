import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import axios from "axios"

const baseUrl = "http://localhost:5004/api/v1/Channel/"

const initialState = {
  response: {},
  status: "idle",
  error: ""
}

export const createChannel = createAsyncThunk("channel/createChannel", async (payload) => {
  const createChannelUrl = "CreateChannel";
  try {
    const response = await axios.post(baseUrl + createChannelUrl, {
      headers:{
        Authorization: `Bearer ${payload.token}`
      }
    });
    console.log(response.data)
    return response?.data
  } catch (error) {
    console.log(error.response.data);
    return error.response.data
  }
})

const channelSlice = createSlice({
  name: "channel",
  initialState,
  reducers: {},
  extraReducers(builder){
    builder
      .addCase(createChannel.pending, (state, action) => {
        state.status = "loading"
      })
      .addCase(createChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(createChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  }
})

export default channelSlice.reducer
export const getResponse = (state) => state.channel.response;
export const getError = (state) => state.channel.error;
export const getStatus = (state) => state.channel.status;