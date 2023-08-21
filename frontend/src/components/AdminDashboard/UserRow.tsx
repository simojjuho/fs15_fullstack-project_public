import { useMemo } from 'react'
import { Avatar, TableCell, TableRow } from '@mui/material'

import UserGet from '../../types/UserGet'

interface UserRowProps {
    user: UserGet
}
const UserRow = ({ user }: UserRowProps) => {
  const child = useMemo(() => {
    return (
      <TableRow className='itemRow'>
        <TableCell>
            <Avatar src={user.avatar} />
        </TableCell>
        <TableCell>{user.id}</TableCell>
        <TableCell>{user.firstName + " " + user.lastName}</TableCell>
        <TableCell>{user.email}</TableCell>
      </TableRow>
    )        
},[user])
  return (
    child
  )
}

export default UserRow