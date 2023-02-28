import { configureStore } from '@reduxjs/toolkit'
import authSlice from './authSlice'
import chatSlice from './chatSlice'
import userSlice from './userSlice'

export const store = configureStore({
  reducer: {
    chat: chatSlice,
    auth: authSlice,
    user: userSlice
  },
})