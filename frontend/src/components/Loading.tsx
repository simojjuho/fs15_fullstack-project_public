import { Container, Typography } from '@mui/material'
import HourglassEmptyIcon from '@mui/icons-material/HourglassEmpty'


const Loading = () => {
  return (
    <Container className='pageContainer'>
        <Typography>
            <HourglassEmptyIcon />
        </Typography>
        <Typography variant='body2' fontSize={'large'}>
            Loading ...
        </Typography>
    </Container>
  )
}

export default Loading