import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://localhost:5004/api/v1/Channel/";

const initialState = {
  createdChannel: {},
  editedChannel: {},
  getChannel: {},
  deleteChannelStatus: null,
  recentActivitiesChannels: [],
  channelAnnoucement: {},
  channelMembers: [],
  status: "idle",
  error: "",
};

export const createChannel = createAsyncThunk(
  "channel/createChannel",
  async (payload) => {
    console.log(payload);
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

export const editChannel = createAsyncThunk(
  "channel/editChannel",
  async (payload) => {
    console.log(payload);
    const editChannelUrl = `EditChannel`;
    try {
      const response = await axios.put(baseUrl + editChannelUrl, payload.data, {
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
      console.log(response.status);
      return response?.status;
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

export const viewRecentActivities = createAsyncThunk(
  "channel/viewrecentactivities",
  async (payload) => {
    console.log(payload);
    const viewRecentActivitiesUrl = `ViewRecentActivities?Id=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + viewRecentActivitiesUrl, {
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

export const getChannelMembers = createAsyncThunk(
  "channel/getChannelMembers",
  async (payload) => {
    console.log(payload);
    const getChannelMembers = `GetChannelMembers?ChannelId=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + getChannelMembers, {
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
        state.createdChannel = action.payload;
      })
      .addCase(createChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(editChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(editChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.editedChannel = action.payload;
      })
      .addCase(editChannel.rejected, (state, action) => {
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
      })
      // /////////////////////////////////////////////////////////
      .addCase(deleteChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deleteChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.deleteChannelStatus = action.payload;
      })
      .addCase(deleteChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(viewRecentActivities.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewRecentActivities.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.recentActivitiesChannels = action.payload;
      })
      .addCase(viewRecentActivities.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(getChannelMembers.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(getChannelMembers.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.channelMembers = action.payload;
      })
      .addCase(getChannelMembers.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
  },
});

export default channelSlice.reducer;
export const getResponseCreatedChannel = (state) => state.channel.createdChannel;
export const getResponseEditedChannel = (state) => state.channel.editedChannel;
export const getResponseGetChannel = (state) => state.channel.getChannel;
export const getResponseGetDeleteChannelStatus = (state) => state.channel.deleteChannelStatus;
export const getResponseViewRecentActivitiesChannel = (state) => state.channel.recentActivitiesChannels;
export const getResponseChannelMembers = (state) => state.channel.channelMembers;
export const getErrorChannel = (state) => state.channel.error;
export const getStatusChannel = (state) => state.channel.status;
