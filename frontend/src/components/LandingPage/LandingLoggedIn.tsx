import { useNavigate } from "react-router-dom"
import { Box, Typography, Button } from "@mui/material"
import isAdmin from "../../utils/isAdmin"
import UserGet from "../../types/UserGet"

interface LandingLoggedInProps {
    user: UserGet
}
const LandingLoggedIn = ({ user }: LandingLoggedInProps) => {
    const navigate = useNavigate()
  return (
    <Box className='landingContent'>
        <Typography variant='h2'>Welcome {user.firstName + " " + user.lastName}!</Typography>
        <Button onClick={() => navigate('/products')} color="secondary" variant="outlined">proceed to webshop</Button>
        {isAdmin() ?<Button onClick={() => navigate('/admin-dashboard')} color="secondary" variant="outlined">proceed to admin dashboard</Button> : null}
    </Box> 
  )
}

export default LandingLoggedIn