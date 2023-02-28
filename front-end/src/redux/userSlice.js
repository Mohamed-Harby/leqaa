import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import axios from "axios"

export const baseUrl = 'http://localhost:5004/api/v1/User/'


const initialState = {
    response: {},
    plan: {},
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
    }
})

export default userSlice.reducer

export const getResponse = (state) => state.user.response
export const getPlan = (state) => state.user.plan
export const getError = (state) => state.user.error
export const getStatus = (state) => state.user.status
