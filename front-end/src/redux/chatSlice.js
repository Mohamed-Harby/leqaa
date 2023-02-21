import { createSlice } from '@reduxjs/toolkit'
import { createAsyncThunk } from '@reduxjs/toolkit'
import axios from "axios"

const baseUrl = 'http://localhost:5002/api/v1/Authentication/'

const msgsDB = 
[
    { msg: "hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1", from: 'micheal8', to: "user3" },
    { msg: "hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1", from: "user3", to: 'micheal8' },
    { msg: "hello3", from: 'micheal8', to: "user3" },
    { msg: "hello4", from: "user3", to: 'micheal8' },
    { msg: "hello3", from: 'micheal8', to: "user4" },
    { msg: "hello4", from: "user4", to: 'micheal8' },
    { msg: "hello3", from: 'micheal8', to: "user5" },
    { msg: "hello4", from: "user5", to: 'micheal8' },
    { msg: "hello5", from: 'micheal8', to: "user5" },
    { msg: "hello6", from: "user5", to: 'micheal8' },
    { msg: "hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1hello1", from: "user3", to: 'micheal8' },
]
const getMsgsDB = []

const initialState = {
    response: null,
    status: "idle",
    error: "",
    msgs: [],
    getMsgs: [],
    auth: false,

}


export const addMsgs = createAsyncThunk("auth/addmsgs", async (payload) => {
    // const signupUrl = 'Register'
    // const response = await axios.post(baseUrl + signupUrl, payload)
    // console.log(response.data)
    // return response?.data
    msgsDB.push(payload)
    const response = {data: payload}
    console.log(response.data)
    return response?.data

})

export const getMsgs = createAsyncThunk("auth/getmsgs", async (payload) => {
    // const loginUrl = 'Login'
    // const response = await axios.post(baseUrl + loginUrl, payload)
    // console.log(response.data)
    // return response?.data
    msgsDB.filter((msg) => {
        if (msg.to == payload || msg.from == payload) {
            getMsgsDB.push(msg)
        }
    })
    const response = {data: getMsgsDB}
    console.log(response.data)
    return response?.data
})

export const getAllMsgs = createAsyncThunk("auth/getallmsgs", async (payload) => {
    const response = {data: msgsDB}
    console.log(response.data)
    return response?.data
})

const chatSlice = createSlice({
    name: 'chat',
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(addMsgs.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(addMsgs.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.msgs.push(action.payload);
            })
            .addCase(addMsgs.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            /////////////////////////////////////////////
            .addCase(getMsgs.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(getMsgs.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.getMsgs = action.payload;
            })
            .addCase(getMsgs.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ///////////////////////////////////////////////
            .addCase(getAllMsgs.pending, (state, action) => {
                state.status = "loading"
            })
            .addCase(getAllMsgs.fulfilled, (state, action) => {
                state.status = "succeeded"
                state.msgs = action.payload;
            })
            .addCase(getAllMsgs.rejected, (state, action) => {
                state.status = "failed"
                state.error = action.error.message
            })
            ///////////////////////////////////////////////
    }
})

export default chatSlice.reducer

export const getChat = (state) => state.chat.getMsgs
export const getAllChat = (state) => state.chat.msgs
export const getChatError = (state) => state.chat.error
export const getChatStatus = (state) => state.chat.status
