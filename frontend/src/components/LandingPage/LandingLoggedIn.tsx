import { useNavigate } from "react-router-dom"
import { Box, Typography, Button } from "@mui/material"
import User from "../../types/User"

interface LandingLoggedInProps {
    user: User
}
const LandingLoggedIn = ({ user }: LandingLoggedInProps) => {
    const navigate = useNavigate()
  return (
    <Box className='landingContent'>
        <Typography variant='h2'>Welcome {user.name}!</Typography>
        <Button onClick={() => navigate('/products')} color="secondary" variant="outlined">proceed to webshop</Button>
        {user.role === 'admin' ?<Button onClick={() => navigate('/admin-dashboard')} color="secondary" variant="outlined">proceed to admin dashboard</Button> : null}
    </Box> 
  )
}

export default LandingLoggedIn