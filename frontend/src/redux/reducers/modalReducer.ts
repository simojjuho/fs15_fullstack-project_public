import { createSlice } from "@reduxjs/toolkit"

const initialState: {
    loginModal: boolean
    registrationModal: boolean
} = {
    loginModal: false,
    registrationModal: false
}

const modalSlice = createSlice({
    name: 'modalReducer',
    initialState: initialState,
    reducers: {
        setRegistrationVisibility: (state) => {
            return {
                loginModal: false,
                registrationModal: !state.registrationModal
            }
        },
        setLoginVisibility: (state) => {
            return {
                loginModal: !state.loginModal,
                registrationModal: false
            }
        },
        initializeModals: () => {
            return initialState
        }
    }
})

export const { setRegistrationVisibility, setLoginVisibility, initializeModals } = modalSlice.actions
const modalReducer = modalSlice.reducer
export default modalReducer
