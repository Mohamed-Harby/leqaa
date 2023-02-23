import { useEffect } from "react"
import { useContext, useState } from "react"
import { useDispatch, useSelector } from "react-redux"
import { authContext } from "../helper/authContext"
import { checkAuth, getAuth, getError, getResponse, getStatus, getUser, login, post, resetPassword, sendResetPasswordEmail, signup } from "../redux/authSlice"
import { setCookies } from "./useCookies"



export const useAuth = () => {
    return useContext(authContext)
}

function useProvideAuth(params) {
    const dispatch = useDispatch()
    const response = useSelector(getResponse);
    // const auth = useSelector(getAuth);
    const [user, setUser] = useState({})
    console.log(response);


    useEffect(() => {
        console.log(response);
        setUser(response)
        response.token && setCookies('token', response.token, 1);
    }, [response])

    function useLogin(payload) {
        dispatch(login(payload))
        console.log(payload);
    }

    function useSignup(payload) {
        dispatch(signup(payload))
        console.log(payload);
    }
    function useGetUser(payload) {
        dispatch(getUser(payload))
        console.log(payload);
    }
    function useSendResetPasswordEmail(payload) {
        dispatch(sendResetPasswordEmail(payload))
        console.log(payload);
    }

    function useResetPassword(payload) {
        dispatch(resetPassword(payload))
        console.log(payload);
    }

    function logout() {
        localStorage.clear();
    }

    return { useSignup, useLogin, useGetUser, useSendResetPasswordEmail, useResetPassword, logout, user, setUser }
}

export function ProvideAuth({ children }) {
    const auth = useProvideAuth();
    return <authContext.Provider value={auth}>{children}</authContext.Provider>;
}
