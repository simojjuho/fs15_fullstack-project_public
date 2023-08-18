import axios, { AxiosError } from "axios"
import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";

import User from "../../types/User"
import NewUser from "../../types/NewUser";
import LoginCredentials from "../../types/LoginCredentials";

const initialState: {
    notification: string,
    isSuccess: boolean
    loading: boolean
    user: User | null,
    users: User[]
} = {
    notification: '',
    isSuccess: false,
    loading: false,
    user: null,
    users: []
}
export const getAllUsers = createAsyncThunk(
    'getAllUsers',
    async () => {
        try {
            const { data } = await axios.get<User[]>('https://api.escuelajs.co/api/v1/users')
            return data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
export const registerUser = createAsyncThunk(
    'registerUser',
    async (newUser: NewUser) => {
        try {
            const { data } = await axios.post<User>('https://api.escuelajs.co/api/v1/users/',  newUser)
            return data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
export const authenticate = createAsyncThunk(
    'getProfile',
    async (access_token: string) => {
        try {
            const { data } = await axios.get<User>('https://api.escuelajs.co/api/v1/auth/profile', {
                headers: {
                    Authorization: `Bearer ${access_token}`
                }
            })
            return data
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
export const loginUser = createAsyncThunk(
    'loginUser',
    async (credentials: LoginCredentials, { dispatch }) => {
        try {
            const { data } = await axios.post<{access_token: string, refresh_token: string}>('https://api.escuelajs.co/api/v1/auth/login', credentials)
            window.localStorage.setItem('token', data.access_token)
            const authentication = await dispatch(authenticate(data.access_token))
            return authentication.payload as User
        } catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)
const userSlice = createSlice({
    name: 'userReducer',
    initialState: initialState,
    reducers: {
        initializeUserNotification: (state) => {
            state.isSuccess = false
            state.notification = ''
        },
        logoutUser: (state) => {
            window.localStorage.clear()
            return initialState
        }
     },
    extraReducers: (build) => {
        build
        .addCase(loginUser.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                state.notification = action.payload.message
            } else {
                state.user = action.payload   
                state.notification = ''             
            }
            state.loading = false
        })
        .addCase(loginUser.pending, (state, action) => {
            state.loading = true
            state.notification = ''
        })
        .addCase(loginUser.rejected, (state, action) => {
            state.loading = false
            state.notification = 'Login failed. Check your username and password'
        })
        .addCase(registerUser.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                state.notification = action.payload.message
            } else {
                console.log(action.payload)
                return {
                    ...state,
                    notification: '',
                    users: state.users.concat(action.payload),
                    isSuccess: true,
                    user: action.payload
                }                 
            }
            state.loading = false
        })
        .addCase(registerUser.pending, (state) => {
            state.loading = true
            state.notification = ''
        })
        .addCase(registerUser.rejected, (state) => {
            state.loading = false
            state.isSuccess = false
            state.notification = 'Could not register the user.'
        })
        .addCase(getAllUsers.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                state.notification = action.payload.message
            } else {
                state.users = action.payload
                state.notification = ''                
            }
            state.loading = false
        })
        .addCase(getAllUsers.pending, (state, action) => {
            state.loading = true
            state.notification = ''
        })
        .addCase(getAllUsers.rejected, (state, action) => {
            state.loading = false
            state.notification = 'Fetching users failed.'
        })
        .addCase(authenticate.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                state.notification = action.payload.message
            } else {
                return {
                    ...state,
                    notification: '',
                    users: state.users.concat(action.payload),
                    isSuccess: true,
                    user: action.payload
                }
            }
            state.loading = false  
        })
    }
})

const userReducer = userSlice.reducer
export default userReducer
export const { initializeUserNotification, logoutUser } = userSlice.actions