import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'
import useAppSelector from '../hooks/useAppSelector'
import jwtDecode from 'jwt-decode'
import isAdmin from '../utils/isAdmin'

interface ProtectedRouteProps {
  Component: React.FC
}
const ProtectedRoute:React.FC<ProtectedRouteProps> = ({ Component }) => {
  return isAdmin() ? <Component /> : <Navigate to={'/'} />
}

export default ProtectedRoute