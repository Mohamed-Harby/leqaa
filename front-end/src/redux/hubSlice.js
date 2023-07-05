import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const baseUrl = "http://4.246.190.37:5004/api/v1/Hub/";

const initialState = {
  createHub: {},
  editedHub: {},
  getHub: {},
  deleteHubStatus: null,
  HubChannels: [],
  HubUsers: [],
  status: "idle",
  error: "",
};

export const deployHub = createAsyncThunk("hub/deployHub", async (payload) => {
  console.log(payload);
  const deployHubUrl = "DeployHub";
  try {
    const response = await axios.post(baseUrl + deployHubUrl, payload.data, {
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
});

export const editHub = createAsyncThunk("channel/editHub", async (payload) => {
  console.log(payload);
  const editHubUrl = `EditHub?id=${payload.id}`;
  try {
    const response = await axios.put(baseUrl + editHubUrl, payload.data, {
      headers: {
        Authorization: `Bearer ${payload.token}`,
      },
    });
    console.log(response.data);
    return response?.data;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

export const deleteHub = createAsyncThunk("hub/deleteHub", async (payload) => {
  console.log(payload);
  const deleteHubUrl = `DeleteHub/${payload.id}`;
  try {
    const response = await axios.delete(baseUrl + deleteHubUrl, {
      headers: {
        Authorization: `Bearer ${payload.token}`,
      },
    });
    console.log(response.status);
    return response?.status;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

export const getHub = createAsyncThunk("hub/getHub", async (payload) => {
  const getHubUrl = `ViewHub?Id=${payload.id}`;
  try {
    const response = await axios.get(baseUrl + getHubUrl, {
      headers: {
        Authorization: `Bearer ${payload.token}`,
      },
    });
    console.log(response.data);
    return response?.data;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

export const viewHubChannels = createAsyncThunk(
  "hub/viewhubchannels",
  async (payload) => {
    const viewHubChannelsUrl = `ViewHubChannels?hubid=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + viewHubChannelsUrl, {
        headers: {
          Authorization: `Bearer ${payload.token}`,
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

export const viewHubUsers = createAsyncThunk(
  "hub/viewhubusers",
  async (payload) => {
    const viewHubUsersUrl = `ViewHubUsers?hubid=${payload.id}`;
    try {
      const response = await axios.get(baseUrl + viewHubUsersUrl, {
        headers: {
          Authorization: `Bearer ${payload.token}`,
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
        state.createHub = action.payload;
      })
      .addCase(deployHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(editHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(editHub.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.editedHub = action.payload;
      })
      .addCase(editHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(getHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(getHub.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.getHub = action.payload;
      })
      .addCase(getHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(deleteHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(deleteHub.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.deleteHubStatus = action.payload;
      })
      .addCase(deleteHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(viewHubChannels.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewHubChannels.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.HubChannels = action.payload;
      })
      .addCase(viewHubChannels.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      // /////////////////////////////////////////////////////////
      .addCase(viewHubUsers.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewHubUsers.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.HubUsers = action.payload;
      })
      .addCase(viewHubUsers.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  },
});

export default hubSlice.reducer;
export const getResponseCreatedHub = (state) => state.hub.createHub;
export const getResponseEditedHub = (state) => state.hub.editedHub;
export const getResponseGetDeleteHubStatus = (state) =>
  state.hub.deleteHubStatus;
export const getResponseGetHub = (state) => state.hub.getHub;
export const getResponseGetHubChannels = (state) => state.hub.HubChannels;
export const getResponseGetHubUsers = (state) => state.hub.HubUsers;
export const getError = (state) => state.hub.error;
export const getStatus = (state) => state.hub.status;
