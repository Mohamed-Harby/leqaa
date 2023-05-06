import { useEffect } from "react"
import { useContext, useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { authContext } from "../helper/authContext"
import { baseUrl, checkAuth, getAuth, getError, getResponse, getStatus, login, post, resetPassword, sendResetPasswordEmail, signup } from "../redux/authSlice"
import { getCookies, setCookies } from "./useCookies"
import axios from "axios"
import { Navigate, redirect, useNavigate } from "react-router-dom"

export const useAuth = () => {
    return useContext(authContext)
}

export const defaultUser = {
    "isSuccess": false,
    "token": "",
    "errorMessages": [],
    "user": null
}

function useProvideAuth(params) {

    const [user, setUser] = useState(defaultUser)
    const [loading, setLoading] = useState(false)
    const token = getCookies('token')

    const useLogin = async (payload) => {
        const loginUrl = 'Login'
        try {
            setLoading(true)
            const response = await axios.post(baseUrl + loginUrl, payload)
            setCookies('token', response.data.token, 1);
            setUser(response.data)
            console.log(response.data)
            console.log('test')
            setLoading(false)
        } catch (error) {
            console.log(error);
            console.log(error.response.data);
            setUser(error.response.data)
            setLoading(false)
        }
    }

    const useSignup = async (payload) => {
        const signupUrl = 'Register'
        try {
            setLoading(true)
            const response = await axios.post(baseUrl + signupUrl, payload)
            setUser(response.data)
            console.log(response.data)
            setLoading(false)
        } catch (error) {
            console.log(error.response.data);
            setUser(error.response.data)
            setLoading(false)
        }
    }

    const useSendResetPasswordEmail = async (payload) => {
        try {
            setLoading(true)
            const sendResetPasswordEmailUrl = `SendResetPasswordEmail?email=${payload.email}`
            const response = await axios.get(baseUrl + sendResetPasswordEmailUrl)
            setUser({ ...response.data, isReset: true })
            console.log(response.data)
            setLoading(false)
        } catch (error) {
            console.log(error.response.data);
            setUser({ ...error.response.data, isReset: false })
            setLoading(false)
        }
    }

    const useResetPassword = async (payload) => {
        try {
            setLoading(true)
            setCookies('token', '', 1);
            const resetPasswordUrl = 'ResetPassword'
            const response = await axios.put(baseUrl + resetPasswordUrl, payload)
            setUser({ ...response.data, isConfirmedReset: true })
            console.log(response.data)
            setLoading(false)
        } catch (error) {
            console.log(error.response.data);
            setUser({ ...error.response.data, isConfirmedReset: false })
            setLoading(false)
        }
    }

    function useLogout() {
        setLoading(true)
        setCookies('token', '', 1);
        setUser(defaultUser)
        setLoading(false)
    }

    useEffect(() => {
        const getUser = () => {
            const getUserUrl = 'GetUser'
            axios.get(baseUrl + getUserUrl, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            }).then((response) => {
                setUser(response.data)
                console.log(response.data);
            }).catch((error) => {
                setCookies('token', '', 1);
                console.log(defaultUser);
                setUser(defaultUser)
            })
        }
        token && getUser()
    }, [])

    return { useSignup, useLogin, useSendResetPasswordEmail, useResetPassword, useLogout, user, setUser, loading }
}

export function ProvideAuth({ children }) {
    const auth = useProvideAuth();
    return <authContext.Provider value={auth}>{children}</authContext.Provider>;
}