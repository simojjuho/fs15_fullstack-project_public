import { Container } from '@mui/material'
import useAppDispatch from '../hooks/useAppDispatch'
import { setRegistrationVisibility, setLoginVisibility } from '../redux/reducers/modalReducer'
import useAppSelector from '../hooks/useAppSelector'
import LandingLoggedIn from '../components/LandingPage/LandingLoggedIn'
import LandingNotLogged from '../components/LandingPage/LandingNotLogged'

const LandingPage = () => {
  const dispatch = useAppDispatch()
  const user = useAppSelector(state => state.userReducer.user)
  const handleRegistrationClick = () => {
    dispatch(setRegistrationVisibility())
  }
  const handleLoginClick = () => {
    dispatch(setLoginVisibility())
  }
  return (
    <Container className='pageContainer' >
      {user 
      ? <LandingLoggedIn user={user} />
      : <LandingNotLogged handleLoginClick={handleLoginClick} handleRegistrationClick={handleRegistrationClick} />}
    </Container>
  )
}

export default LandingPage