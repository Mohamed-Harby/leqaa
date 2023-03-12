import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import axios from "axios"

export const baseUrl = 'http://localhost:5004/api/v1/User/'


const initialState = {
    plan: {},
    response: {},
    userChannels: [],
    userHubs: [],
    friends: [],
    user: {},
    status: "idle",
    error: "",
}



export const buyPlan = createAsyncThunk("user/buyplan", async (payload) => {
    const buyPlanUrl = 'BuyPlan'
    try {
        const response = await axios.post(baseUrl + buyPlanUrl, payload.data, {
            headers: {
                Authorization: `Bearer ${payload.token}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const setProfilePicture = createAsyncThunk("user/setprofilepicture", async (payload) => {
    const setProfilePictureUrl = 'SetProfilePicture'
    try {
        let response = await axios.put(baseUrl + setProfilePictureUrl, payload.profilePicture, {
            headers: {
                Authorization: `Bearer ${payload.token}`
            }
        })
        console.log(response?.data);
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const viewUserProfile = createAsyncThunk("user/viewuserprofile", async (payload) => {
    const viewUserProfileUrl = 'ViewUserProfile'
    try {
        const response = await axios.get(baseUrl + viewUserProfileUrl, {
            headers: {
                Authorization: `Bearer ${payload}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const viewUserChannels = createAsyncThunk("user/viewuserchannels", async (payload) => {
    const viewUserChannelsUrl = 'ViewUserChannels'
    try {
        const response = await axios.get(baseUrl + viewUserChannelsUrl, {
            headers: {
                Authorization: `Bearer ${payload}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const viewUserHubs = createAsyncThunk("user/viewuserhubs", async (payload) => {
    const viewUserHubsUrl = 'ViewUserHubs'
    try {
        const response = await axios.get(baseUrl + viewUserHubsUrl, {
            headers: {
                Authorization: `Bearer ${payload}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const followUser = createAsyncThunk("user/followuser", async (payload) => {
    const followUserUrl = 'FollowUser'
    try {
        const response = await axios.post(baseUrl + followUserUrl, payload.data,{
            headers: {
                Authorization: `Bearer ${payload.token}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const viewUsers = createAsyncThunk("user/viewusers", async (payload) => {
    const viewUsersUrl = 'ViewUsers?pageNumber=1&pageSize=20'
    try {
        const response = await axios.get(baseUrl + viewUsersUrl, {
            headers: {
                Authorization: `Bearer ${payload}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const viewUser = createAsyncThunk("user/viewuser", async (payload) => {
    const viewUserUrl = `ViewUser?UserName=${payload.data}`
    try {
        const response = await axios.get(baseUrl + viewUserUrl, {
            headers: {
                Authorization: `Bearer ${payload.token}`
            }
        })
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})


const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(buyPlan.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(buyPlan.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.plan = action.payload;
            })
            .addCase(buyPlan.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ////////////////////////////////////////////////////////////
            .addCase(setProfilePicture.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(setProfilePicture.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(setProfilePicture.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            //////////////////////////////////////////////////////
            .addCase(viewUserProfile.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(viewUserProfile.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(viewUserProfile.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            //////////////////////////////////////////////////////
            .addCase(viewUserChannels.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(viewUserChannels.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.userChannels = action.payload;
            })
            .addCase(viewUserChannels.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            //////////////////////////////////////////////////////
            .addCase(viewUserHubs.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(viewUserHubs.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.userHubs = action.payload;
            })
            .addCase(viewUserHubs.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            //////////////////////////////////////////////////////
            .addCase(viewUsers.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(viewUsers.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.friends = action.payload;
            })
            .addCase(viewUsers.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            //////////////////////////////////////////////////////
            .addCase(viewUser.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(viewUser.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.user = action.payload;
            })
            .addCase(viewUser.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
    }
})

export default userSlice.reducer

export const getResponse = (state) => state.user.response
export const getResponseUserChannels = (state) => state.user.userChannels
export const getResponseUserHubs = (state) => state.user.userHubs
export const getResponseUserFriends = (state) => state.user.friends
export const getResponseUser = (state) => state.user.user
export const getPlan = (state) => state.user.plan
export const getError = (state) => state.user.error
export const getStatus = (state) => state.user.status
