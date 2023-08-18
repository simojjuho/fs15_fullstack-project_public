import { useNavigate } from "react-router-dom"
import { Box, Typography, Button } from "@mui/material"

interface LandingNotLoggedProps {
    handleLoginClick: () => void
    handleRegistrationClick: () => void
}
const LandingNotLogged = ({ handleLoginClick, handleRegistrationClick}: LandingNotLoggedProps) => {
    const navigate = useNavigate()
  return (
    <Box className='landingContent'>
        <Typography variant='h2'>
            Welcome!
        </Typography>
        <Box id='landingProfileActions'>
            <Button onClick={handleLoginClick} color="secondary" variant="outlined">Log in</Button > or
            <Button onClick={handleRegistrationClick} color="secondary" variant="outlined">Sign up</Button >
        </Box>
        <Box id='landingProceed'>
            <Typography variant='body1'>
            You can also proceed to the webshop without signing up.
            </Typography>
            <Button onClick={() => navigate('/products')} color="secondary" variant="outlined">proceed to webshop</Button>
            
        </Box>
    </Box>
  )
}

export default LandingNotLogged