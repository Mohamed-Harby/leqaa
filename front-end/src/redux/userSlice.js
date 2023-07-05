import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const baseUrl = "http://4.246.190.37:5004/api/v1/User/";

const initialState = {
  plan: {},
  response: {},
  userChannels: [],
  userHubs: [],
  friends: [],
  user: {},
  HubsWithoutUserHubs: [],
  status: "idle",
  error: "",
};

export const buyPlan = createAsyncThunk("user/buyplan", async (payload) => {
  const buyPlanUrl = "BuyPlan";
  try {
    const response = await axios.post(baseUrl + buyPlanUrl, payload.data, {
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

export const setProfilePicture = createAsyncThunk(
  "user/setprofilepicture",
  async (payload) => {
    const setProfilePictureUrl = "SetProfilePicture";
    try {
      let response = await axios.put(
        baseUrl + setProfilePictureUrl,
        payload.profilePicture,
        {
          headers: {
            Authorization: `Bearer ${payload.token}`,
          },
        }
      );
      console.log(response?.data);
      return response?.data;
    } catch (error) {
      console.log(error.response.data);
      return error.response.data;
    }
  }
);

export const viewUserProfile = createAsyncThunk(
  "user/viewuserprofile",
  async (payload) => {
    const viewUserProfileUrl = "ViewUserProfile";
    try {
      const response = await axios.get(baseUrl + viewUserProfileUrl, {
        headers: {
          Authorization: `Bearer ${payload}`,
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

export const viewUserChannels = createAsyncThunk(
  "user/viewuserchannels",
  async (payload) => {
    const viewUserChannelsUrl = "ViewUserChannels";
    try {
      const response = await axios.get(baseUrl + viewUserChannelsUrl, {
        headers: {
          Authorization: `Bearer ${payload}`,
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

export const viewUserHubs = createAsyncThunk(
  "user/viewuserhubs",
  async (payload) => {
    const viewUserHubsUrl = "ViewUserHubs";
    try {
      const response = await axios.get(baseUrl + viewUserHubsUrl, {
        headers: {
          Authorization: `Bearer ${payload}`,
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

export const followUser = createAsyncThunk(
  "user/followuser",
  async (payload) => {
    const followUserUrl = "FollowUser";
    try {
      const response = await axios.post(baseUrl + followUserUrl, payload.data, {
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

export const viewUsers = createAsyncThunk("user/viewusers", async (payload) => {
  const viewUsersUrl = "ViewUsers?pageNumber=1&pageSize=20";
  try {
    const response = await axios.get(baseUrl + viewUsersUrl, {
      headers: {
        Authorization: `Bearer ${payload}`,
      },
    });
    console.log(response.data);
    return response?.data;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

export const viewUser = createAsyncThunk("user/viewuser", async (payload) => {
  const viewUserUrl = `ViewUser?UserName=${payload.username}`;
  try {
    const response = await axios.get(baseUrl + viewUserUrl, {
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

export const joinHub = createAsyncThunk("user/joinhub", async (payload) => {
  const joinHubUrl = `JoinHub`;
  try {
    const response = await axios.put(baseUrl + joinHubUrl, payload.data, {
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

export const leaveHub = createAsyncThunk("user/leavehub", async (payload) => {
  console.log(payload);
  const leaveHubUrl = `LeaveHub?hubID=${payload.id}`;
  try {
    const response = await axios.delete(baseUrl + leaveHubUrl, {
      headers: {
        Authorization: `Bearer ${payload.token}`,
      },
    });
    console.log(response);
    return response?.data;
  } catch (error) {
    console.log(error.response.data);
    return error.response.data;
  }
});

export const leaveChannel = createAsyncThunk(
  "user/leavechannel",
  async (payload) => {
    const leaveChannelUrl = `LeavChannel?ChannelID=${payload.id}`;
    try {
      const response = await axios.delete(baseUrl + leaveChannelUrl, {
        headers: {
          Authorization: `Bearer ${payload.token}`,
        },
      });
      console.log(response);
      return response?.data;
    } catch (error) {
      console.log(error.response.data);
      return error.response.data;
    }
  }
);

export const getHubsWithoutUserHubs = createAsyncThunk(
  "user/gethubswithoutuserhubs",
  async (payload) => {
    console.log(payload);
    const getHubsWithoutUserHubsUrl = `GetHubsWithoutUserHubs`;
    try {
      const response = await axios.get(baseUrl + getHubsWithoutUserHubsUrl, {
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

export const joinChannel = createAsyncThunk(
  "user/joinChannel",
  async (payload) => {
    const joinChannelUrl = `JoinChannel`;
    try {
      const response = await axios.post(
        baseUrl + joinChannelUrl,
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
      console.log(error.response.data);
      return error.response.data;
    }
  }
);

export const pinChannel = createAsyncThunk(
  "user/pinchannel",
  async (payload) => {
    const pinChannelUrl = `PinChannel`;
    try {
      const response = await axios.post(baseUrl + pinChannelUrl, payload.data, {
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

export const pinHub = createAsyncThunk("user/pinhub", async (payload) => {
  const pinHubUrl = `PinHub`;
  try {
    const response = await axios.post(baseUrl + pinHubUrl, payload.data, {
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

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {},
  extraReducers(builder) {
    builder
      .addCase(buyPlan.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(buyPlan.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.plan = action.payload;
      })
      .addCase(buyPlan.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      ////////////////////////////////////////////////////////////
      .addCase(setProfilePicture.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(setProfilePicture.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(setProfilePicture.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(viewUserProfile.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewUserProfile.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.response = action.payload;
      })
      .addCase(viewUserProfile.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(viewUserChannels.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewUserChannels.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.userChannels = action.payload;
      })
      .addCase(viewUserChannels.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(viewUserHubs.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewUserHubs.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.userHubs = action.payload;
      })
      .addCase(viewUserHubs.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(viewUsers.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewUsers.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.friends = action.payload;
      })
      .addCase(viewUsers.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(viewUser.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(viewUser.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.user = action.payload;
      })
      .addCase(viewUser.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(joinHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(joinHub.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(joinHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(leaveHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(leaveHub.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(leaveHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(leaveChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(leaveChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(leaveChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(getHubsWithoutUserHubs.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(getHubsWithoutUserHubs.fulfilled, (state, action) => {
        state.status = "succeeded";
        state.HubsWithoutUserHubs = action.payload;
      })
      .addCase(getHubsWithoutUserHubs.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(joinChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(joinChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(joinChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(pinChannel.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(pinChannel.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(pinChannel.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      })
      //////////////////////////////////////////////////////
      .addCase(pinHub.pending, (state, action) => {
        state.status = "loading";
      })
      .addCase(pinHub.fulfilled, (state, action) => {
        state.status = "succeeded";
      })
      .addCase(pinHub.rejected, (state, action) => {
        state.status = "failed";
        state.error = action.error.message;
      });
  },
});

export default userSlice.reducer;

export const getResponse = (state) => state.user.response;
export const getResponseUserChannels = (state) => state.user.userChannels;
export const getResponseUserHubs = (state) => state.user.userHubs;
export const getResponseUserFriends = (state) => state.user.friends;
export const getResponseUser = (state) => state.user.user;
export const getResponseHubsWithoutUserHubs = (state) =>
  state.user.HubsWithoutUserHubs;
export const getPlan = (state) => state.user.plan;
export const getError = (state) => state.user.error;
export const getStatus = (state) => state.user.status;
