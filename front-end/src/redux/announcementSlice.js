import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://4.246.190.37:5004/api/v1/Annoucement/";

const initialState = {
  channelAnnoucement: {},
  hubAnnoucement: {},
  hubAnnoucements: [],
  status: "idle",
  error: "",
};

export const deployChannelAnnoucement = createAsyncThunk(
  "announcement/deployChannelAnnoucement",
  async (payload) => {
    console.log(payload);
    const deployChannelAnnoucementUrl = `DeployChannelAnnoucement`;
    try {
      const response = await axios.post(
        baseUrl + deployChannelAnnoucementUrl,
        payload.data,
        {
          headers: {
            Authorization: `Bearer ${payload.token}`,
          },
        }
      );
      console.log(response.data);
      return response?.data;
    } catch (error) {
      console.log(error);
      return error.response.data;
    }
  }
);

export const deployHubAnnoucement = createAsyncThunk(
  "announcement/deployHubAnnoucement",
  async (payload) => {
    console.log(payload);
    const deployHubAnnoucementUrl = `DeployHubAnnoucement`;
    try {
      const response = await axios.post(
        baseUrl + deployHubAnnoucementUrl,
        payload.data,
        {
          headers: {
            Authorization: `Bearer ${payload.token}`,
          },
        }
      );
      console.log(response.data);
      return response?.data;
    } catch (error) {
      console.log(error);
      return error.response.data;
    }
  }
);

export const getHubAnnoucements = createAsyncThunk(
  "announcement/getHubAnnoucements",
  async (payload) => {
    console.log(payload);
    const getHubAnnoucementsUrl = `GetHubAnnoucements?HubId=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + getHubAnnoucementsUrl, {
        headers: {
          Authorization: `Bearer ${payload.token}`,
        },
      });
      console.log(response.data);
      return response?.data;
    } catch (error) {
      console.log(error);
      return error.response.data;
    }
  }
);

const announcementSlice = createSlice({
  name: "announcement",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(deployChannelAnnoucement.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deployChannelAnnoucement.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.channelAnnoucement = action.payload;
      })
      .addCase(deployChannelAnnoucement.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      ////////////////////////////////////////////////////////
      .addCase(deployHubAnnoucement.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deployHubAnnoucement.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.hubAnnoucement = action.payload;
      })
      .addCase(deployHubAnnoucement.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      ////////////////////////////////////////////////////////
      .addCase(getHubAnnoucements.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(getHubAnnoucements.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.hubAnnoucements = action.payload;
      })
      .addCase(getHubAnnoucements.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
    ////////////////////////////////////////////////////////
  },
});

export default announcementSlice.reducer;
export const getResponseChannelAnnoucement = (state) =>
  state.announcement.channelAnnoucement;
export const getResponsehubAnnoucement = (state) =>
  state.announcement.hubAnnoucement;
export const getResponseGethubAnnoucements = (state) =>
  state.announcement.hubAnnoucements;
export const getErrorChannel = (state) => state.announcement.error;
export const getStatusChannel = (state) => state.announcement.status;
