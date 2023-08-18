import { Button, Dialog, DialogActions, DialogContent, DialogTitle, TextField } from '@mui/material'
import { useEffect, useState } from 'react'

import useAppSelector from '../../hooks/useAppSelector'
import { setLoginVisibility } from '../../redux/reducers/modalReducer'
import useInput from '../../hooks/useInput'
import { loginUser } from '../../redux/reducers/userReducer'
import LoginCredentials from '../../types/LoginCredentials'
import useAppDispatch from '../../hooks/useAppDispatch'
import Notification from '../Notification'
import LoginTextfields from './LoginTextfields'
import LoginSuccess from './LoginSuccess'

const LoginModal = () => {
    const isOpen = useAppSelector(state => state.modalReducer.loginModal)
    const dispatch = useAppDispatch()
    const userReducer = useAppSelector(state => state.userReducer)
    const emailInput = useInput('')
    const passwordInput = useInput('')
    const handleLogin = () => {
        if(emailInput.value && passwordInput.value) {
            const credentials: LoginCredentials = {
                email: emailInput.value,
                password: passwordInput.value
            }
            dispatch(loginUser(credentials))           
        }
    }
    return (
        <Dialog open={isOpen} onClose={() => dispatch(setLoginVisibility())}>
            <DialogTitle>Log in</DialogTitle>
            { userReducer.notification
                ? <Notification message={'Login failed. Check your email and/or password!'} severity={'error'} type='user' />
                : null
            }
            {userReducer.user ? <LoginSuccess /> : <LoginTextfields emailInput={emailInput} passwordInput={passwordInput} handleLogin={handleLogin}/>}
            
        </Dialog>
    )
}

export default LoginModal