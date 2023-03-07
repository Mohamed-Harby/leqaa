import { configureStore } from '@reduxjs/toolkit'
import authSlice from './authSlice'
import channelSlice from './channelSlice'
import chatSlice from './chatSlice'
import hubSlice from './hubSlice'
import userSlice from './userSlice'

export const store = configureStore({
  reducer: {
    chat: chatSlice,
    auth: authSlice,
    user: userSlice,
    hub: hubSlice,
    channel: channelSlice
  },
})