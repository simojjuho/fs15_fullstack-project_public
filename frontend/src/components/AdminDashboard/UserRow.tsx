import { useMemo } from 'react'
import { Avatar, Icon, TableCell, TableRow } from '@mui/material'

import User from '../../types/User'

interface UserRowProps {
    user: User
}
const UserRow = ({ user }: UserRowProps) => {
  const child = useMemo(() => {
    return (
      <TableRow className='itemRow'>
        <TableCell>
            <Avatar src={user.avatar} />
        </TableCell>
        <TableCell>{user.id}</TableCell>
        <TableCell>{user.name}</TableCell>
        <TableCell>{user.role}</TableCell>
        <TableCell>{user.email}</TableCell>
      </TableRow>
    )        
},[user])
  return (
    child
  )
}

export default UserRow