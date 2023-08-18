import { Button, Container, Typography } from '@mui/material'
import React from 'react'
import { useNavigate } from 'react-router-dom'

const ErrorPage = () => {
  const navigate = useNavigate()
  const handleClick = () => navigate('/')
  return (
    <Container className='pageContainer'>
      <Typography variant='h2'>Ooooopss.....</Typography>
      <Typography>Looks like there's nothing in this address.</Typography>
      <Button onClick={handleClick} variant='outlined' color='secondary'>back to the front page</Button>
    </Container>
  )
}

export default ErrorPage