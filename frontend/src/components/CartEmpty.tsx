import { useNavigate } from 'react-router-dom'
import SentimentDissatisfiedIcon from '@mui/icons-material/SentimentDissatisfied'
import { Container, Typography, Button } from '@mui/material'

const CartEmpty = () => {
    const navigate = useNavigate()    
    return (
        <Container className='pageContainer' >
            <Typography>
                <SentimentDissatisfiedIcon sx={{ fontSize: 65 }}/>
            </Typography>
            <Typography>
                Shopping cart is empty. Add something in it to make it happy!
            </Typography>
            <Button variant='outlined' color='secondary' onClick={() => navigate('/products')}>Back to products</Button>
        </Container>    
    )
}

export default CartEmpty