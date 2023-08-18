import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import useAppSelector from '../hooks/useAppSelector'

interface ProtectedRouteProps {
  Component: React.FC
}
const ProtectedRoute:React.FC<ProtectedRouteProps> = ({ Component }) => {
  const { user } = useAppSelector(state => state.userReducer)
  const isAdmin = user?.role === 'admin'

  return isAdmin ? <Component /> : <Navigate to={'/'} />
}

export default ProtectedRoute