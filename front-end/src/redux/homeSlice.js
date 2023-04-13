import { createSlice } from "@reduxjs/toolkit";
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { viewRecentActivities } from "./channelSlice";

const baseUrl = "http://localhost:5004/Home/";

const initialState = {
    recentActivities: [],
    status: "idle",
    error: "",
};

export const viewRecentActivitiesHome = createAsyncThunk(
    "home/viewRecentActivities",
    async (payload) => {
        console.log(payload);
        const viewRecentActivities = `ViewRecentActivities`;
        try {
            const response = await axios.get(baseUrl + viewRecentActivities, {
                headers: {
                    Authorization: `Bearer ${payload.token}`
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

const homeSlice = createSlice({
    name: "home",
    initialState,
    reducers: {},
    extraReducers(builder) {
        builder
            .addCase(viewRecentActivitiesHome.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(viewRecentActivitiesHome.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.recentActivities = action.payload;
            })
            .addCase(viewRecentActivitiesHome.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            ////////////////////////////////////////////////////////
    },
});

export default homeSlice.reducer;
export const getResponseRecentActivities = (state) => state.home.recentActivities;
export const getErrorChannel = (state) => state.home.error;
export const getStatusChannel = (state) => state.home.status;
