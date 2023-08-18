import { Button, DialogActions, DialogContent } from '@mui/material'

import Notification from '../Notification'
import useAppDispatch from '../../hooks/useAppDispatch'
import { setLoginVisibility } from '../../redux/reducers/modalReducer'

const LoginSuccess = () => {
  const dispatch = useAppDispatch()
  return (
    <>
      <DialogContent>
        <Notification message={'Login succesful'} severity={'success'} type='user'/>
      </DialogContent>
      <DialogActions>
        <Button variant='outlined' color='secondary' onClick={() => dispatch(setLoginVisibility())}>Close</Button>
      </DialogActions>
    </>
  )
}

export default LoginSuccess