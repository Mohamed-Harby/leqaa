import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import axios from "axios"

export const baseUrl = 'http://localhost:5002/api/v1/Authentication/'


const initialState = {
    response: {},
    status: "idle",
    error: "",
    auth: false
}



export const signup = createAsyncThunk("auth/signup", async (payload) => {
    const signupUrl = 'Register'
    try {
        const response = await axios.post(baseUrl + signupUrl, payload)
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const login = createAsyncThunk("auth/login", async (payload) => {
    const loginUrl = 'Login'
    try {
        const response = await axios.post(baseUrl + loginUrl, payload)
        console.log(response.data)
        return response?.data
    } catch (error) {
        console.log(error.response.data);
        return error.response.data
    }
})

export const getUser = createAsyncThunk("auth/getuser", async (payload) => {
    const getUserUrl = 'GetUser'
    const response = await axios.get(baseUrl + getUserUrl,{
        headers:{
            Authorization: `Bearer ${payload}`
        }
    })
    console.log(response.data)
    return response?.data
})

export const sendResetPasswordEmail = createAsyncThunk("auth/sendResetPasswordEmail", async (payload) => {
    const sendResetPasswordEmailUrl = `SendResetPasswordEmail?email=${payload.email}`
    const response = await axios.get(baseUrl + sendResetPasswordEmailUrl)
    console.log(response.data)
    return response?.data
})

export const resetPassword = createAsyncThunk("auth/resetpassword", async (payload) => {
    const resetPasswordUrl = 'ResetPassword'
    const response = await axios.put(baseUrl + resetPasswordUrl,payload)
    console.log(response.data)
    return response?.data
})

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(signup.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(signup.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(signup.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            /////////////////////////////////////////////
            .addCase(login.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(login.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(login.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ///////////////////////////////////////////////
            .addCase(getUser.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(getUser.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(getUser.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ////////////////////////////////////////////////
            .addCase(sendResetPasswordEmail.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(sendResetPasswordEmail.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(sendResetPasswordEmail.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ////////////////////////////////////////////////
            .addCase(resetPassword.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(resetPassword.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.response = action.payload;
            })
            .addCase(resetPassword.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ////////////////////////////////////////////////
    }
})

export default authSlice.reducer

export const getResponse = (state) => state.auth.response
export const getError = (state) => state.auth.error
export const getStatus = (state) => state.auth.status
export const getAuth = (state) => state.auth.auth