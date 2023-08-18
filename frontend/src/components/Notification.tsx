import { useEffect } from 'react'
import { Alert, AlertColor, AlertTitle } from '@mui/material'

import useAppDispatch from '../hooks/useAppDispatch'
import { initializeUserNotification } from '../redux/reducers/userReducer'
import { initializeProductNotifications } from '../redux/reducers/productsReducer'

interface NotificationProps {
    message: string,
    severity: AlertColor
    type: 'user' | 'product'
}
const Notification = ({ message, severity, type }: NotificationProps) => {
    const dispatch = useAppDispatch()
    useEffect(() => {
        setTimeout(() => {
            switch (type) {
                case 'user':
                    dispatch(initializeUserNotification())
                    break
                case 'product':
                    dispatch(initializeProductNotifications())
                    break
            }
            
        }, 5000)
    }, [])
    return (
        <Alert severity={severity}>
            <AlertTitle>{severity}</AlertTitle>
            {message}
        </Alert>
        )

}

export default Notification