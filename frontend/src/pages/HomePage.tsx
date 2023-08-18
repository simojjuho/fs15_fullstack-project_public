import { Outlet } from 'react-router-dom'
import { useEffect } from 'react';
import { Box } from '@mui/material'

import useAppDispatch from '../hooks/useAppDispatch';
import { getAllProducts } from '../redux/reducers/productsReducer';
import Footer from '../components/Footer';
import Header from '../components/Header';
import LoginModal from '../components/ProfileModals/LoginModal';
import RegisterModal from '../components/ProfileModals/RegisterModal';
import { authenticate, getAllUsers } from '../redux/reducers/userReducer';
import useAppSelector from '../hooks/useAppSelector';
import { getAllCategories } from '../redux/reducers/categoryReducer';

const HomePage = () => {
  const dispatch = useAppDispatch()
  const user = useAppSelector(state => state.userReducer.user)
  useEffect(() => {
    dispatch(getAllProducts())
    dispatch(getAllCategories())
  }, [])
  useEffect(() => {
    if(!user) {
      const token = window.localStorage.getItem('token')
      if(token) {
        dispatch(authenticate(token))
      }
    }
    dispatch(getAllUsers())
  },[dispatch, user])
  return (
    <Box sx={{position: 'relative',minHeight: '100vh', backgroundColor: 'info.main' }}>
      <Header />
      <LoginModal />
      <RegisterModal />
      <Outlet />
      <Footer />
    </Box>
  )
}

export default HomePage