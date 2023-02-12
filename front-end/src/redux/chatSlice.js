import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import axios from 'axios'

export const post = createAsyncThunk(
    'crud/post',
    async (payload) => {
        try {
            console.log(payload);
            return payload
        } catch (error) {
            console.log(error);
        }
    }
)

export const get = createAsyncThunk(
    'crud/get',
    async (url) => {
        try {
            // const res = await axios.get(url)
            // return res.data
        } catch (error) {
            console.log(error);
        }
    }
)

// export const post = createAsyncThunk(
//     'crud/post',
//     async (url, payload) => {
//         try {
//             const res = await axios.post(url, payload)
//             return res.data
//         } catch (error) {
//             console.log(error);
//         }
//     }
// )

// export const get = createAsyncThunk(
//     'crud/get',
//     async (url) => {
//         try {
//             // const res = await axios.get(url)
//             // return res.data
//         } catch (error) {
//             console.log(error);
//         }
//     }
// )

// export const remove = createAsyncThunk(
//     'crud/remove',
//     async (url) => {
//         try {
//             const res = await axios.delete(url)
//             return res.data
//         } catch (error) {
//             console.log(error);
//         }
//     }
// )

// export const update = createAsyncThunk(
//     'crud/update',
//     async (url, payload) => {
//         try {
//             const res = await axios.patch(url, payload)
//             return res.data
//         } catch (error) {
//             console.log(error);
//         }
//     }
// )

export const chatSlice = createSlice({
    name: 'data',
    initialState: {
        responseMsg: null,
        msgs: []
    },
    reducers: {},
    extraReducers: {
        // post
        [post.pending]: (state, action) => {
            state.responseMsg = 'loading'
        },
        [post.fulfilled]: (state, action) => {
            // state.responseMsg = action.payload
            state.msgs.push(action.payload)
        },
        [post.rejected]: (state, action) => {
            state.responseMsg = 'failed'
        },
        // /////////////////////////////////////////////////////////////////
        // get
        [get.pending]: (state, action) => {
            state.responseMsg = 'loading'
        },
        [get.fulfilled]: (state, action) => {
            state.responseMsg = action.payload
        },
        [get.rejected]: (state, action) => {
            state.responseMsg = 'failed'
        },
        // /////////////////////////////////////////////////////////////////
        // // remove
        // [remove.pending]: (state, action) => {
        //     state.responseMsg = 'loading'
        // },
        // [remove.fulfilled]: (state, action) => {
        //     state.responseMsg = action.payload
        // },
        // [remove.rejected]: (state, action) => {
        //     state.responseMsg = 'failed'
        // },
        // // /////////////////////////////////////////////////////////////////
        // // update
        // [update.pending]: (state, action) => {
        //     state.responseMsg = 'loading'
        // },
        // [update.fulfilled]: (state, action) => {
        //     state.responseMsg = action.payload
        // },
        // [update.rejected]: (state, action) => {
        //     state.responseMsg = 'failed'
        // },
    }
})




// export const {  } = counterSlice.actions

export default chatSlice.reducer