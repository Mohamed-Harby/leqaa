import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://localhost:5004/api/v1/Hub/";

const initialState = {
  response: {},
  status: "idle",
  error: "",
};

export const deployHub = createAsyncThunk("hub/deployHub", async (payload) => {
  const deployHubUrl = "DeployHub";
  const headers = {
    "Content-Type": "application/json",
    Authorization: `Bearer ${payload.token}`,
  };
  const data = {
    name: payload.name,
    description: payload.description,
  };
  try {
    const response = await axios.post(baseUrl + deployHubUrl, data, {
      headers: headers,
    });
    console.log(response.data);
    return response?.data;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

const hubSlice = createSlice({
  name: "hub",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(deployHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deployHub.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(deployHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  },
});

export default hubSlice.reducer;
export const getResponse = (state) => state.hub.response;
export const getError = (state) => state.hub.error;
export const getStatus = (state) => state.hub.status;
