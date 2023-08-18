import { DialogContent, TextField, DialogActions, Button } from '@mui/material'

import useAppDispatch from '../../hooks/useAppDispatch'
import { setLoginVisibility } from '../../redux/reducers/modalReducer'

interface LoginTextfieldsProps {
    emailInput: {
        value: string | undefined;
        onChange: (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    }
    passwordInput: {
        value: string | undefined;
        onChange: (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    }
    handleLogin: () => void
}
const LoginTextfields = ({ emailInput, passwordInput, handleLogin}: LoginTextfieldsProps) => {
    const dispatch = useAppDispatch()
  return (
    <>
    <DialogContent className='modalForm'>
        <TextField 
            label='Email address'
            color='secondary'
            {...emailInput}
            className='formInput'
        />
        <TextField
            label='Password'
            color='secondary'
            type='password'
            {...passwordInput}
            className='formInput'
        />
    </DialogContent>
    <DialogActions>
        <Button onClick={handleLogin} variant='outlined' color='secondary'>Log in</Button>
        <Button onClick={() => dispatch(setLoginVisibility())} variant='outlined' color='secondary'>Cancel</Button>
    </DialogActions>
    </>
  )
}

export default LoginTextfields