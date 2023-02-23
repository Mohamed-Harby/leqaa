import { configureStore } from '@reduxjs/toolkit'
import authSlice from './authSlice'
import chatSlice from './chatSlice'

export const store = configureStore({
  reducer: {
    chat: chatSlice,
    auth: authSlice
  },
})