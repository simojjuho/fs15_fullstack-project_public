import { useNavigate } from 'react-router-dom'
import useAppSelector from '../hooks/useAppSelector'
import { Box, Container, Typography } from '@mui/material'

import { getAllUsers } from '../redux/reducers/userReducer'
import UserList from '../components/AdminDashboard/UserList'
import ProductsListDashboard from '../components/AdminDashboard/ProductsListDashboard'
import { useEffect } from 'react'
import useAppDispatch from '../hooks/useAppDispatch'

const AdminPage = () => {
    const dispatch = useAppDispatch()
    useEffect(() => {
        dispatch(getAllUsers())
    }, [])
    const user = useAppSelector(state => state.userReducer.user)
    const navigate = useNavigate()
    if (!user) {
        navigate('/')
    }
    return (
        <Container maxWidth='lg' id='adminPage' sx={{
            padding: '8em 0'
        }}>
            <Typography variant='h2'>Admin Dashboard</Typography>
            <Box sx={{
                marginTop: '3em'
            }}>
                {}
                <Typography sx={{marginBottom: '3em'}} variant='h3'>Add / edit products</Typography>
                <ProductsListDashboard />
                <Typography variant='h3'>Add / edit users</Typography>
                <UserList />
            </Box>
        </Container>
    )
}

export default AdminPage