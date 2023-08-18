import { Avatar, Container, Typography, Box, Paper } from '@mui/material'
import useAppSelector from '../hooks/useAppSelector'
import { useNavigate, useParams } from 'react-router-dom'

const UserProfilePage = () => {
  const id = useParams().id
  const navigate = useNavigate()
  const { user } = useAppSelector(state => state.userReducer)  
  if(!user) return null
  return (
    <Container className='pageContainer'>
      <Paper sx={{padding: '5em', display: 'flex', flexDirection: 'column', gap: 5}}>
        <Box sx={{display: 'flex', alignItems: 'center', gap: 5}}>
          <Avatar
            sx={{ width: 150, height: 150 }}
            alt={user.name}
            src={user.avatar}/>
            <Typography variant='h2'>{user.name}</Typography>
        </Box>
        <Box>
          <Typography>Email: {user.email}</Typography>
          <Typography>Role: {user.role}</Typography>
        </Box>
      </Paper>
    </Container>
  )
}

export default UserProfilePage