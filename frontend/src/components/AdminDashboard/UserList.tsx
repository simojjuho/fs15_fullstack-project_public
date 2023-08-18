import { TableContainer, Paper, Table, TableBody, TableRow, TableCell, TableFooter, TablePagination } from '@mui/material'
import TablePaginationActions from '@mui/material/TablePagination/TablePaginationActions'

import useAppSelector from '../../hooks/useAppSelector'
import { useState } from 'react'
import UserRow from './UserRow'

const UserList = () => {
    const [page, setPage] = useState(0)
    const [itemssPerPage, setUsersPerPage] = useState(10)
    const users = useAppSelector(state => state.userReducer.users)
    const emptyRows = page > 0 ? Math.max(0, (1 + page) * itemssPerPage - users.length) : 0
    const handleChangePage = (
        event: React.MouseEvent<HTMLButtonElement> | null,
        newPage: number,
      ) => {
        setPage(newPage)
    }
    const handleChangeRowsPerPage = (
        event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
        ) => {
        setUsersPerPage(parseInt(event.target.value, 10))
        setPage(0)
    }
    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 500 }} aria-label="custom pagination table">
                <TableBody>
                    {(itemssPerPage > 0
                    ? users.slice(page * itemssPerPage, page * itemssPerPage + itemssPerPage)
                    : users
                    ).map(user => <UserRow key={user.id} user={user}/>)}
                    {emptyRows > 0 && (
                    <TableRow style={{ height: 73 * emptyRows }}>
                        <TableCell colSpan={6} />
                    </TableRow>
                     )}
                </TableBody>
                <TableFooter>
                <TableRow>
                    <TablePagination
                    rowsPerPageOptions={[5, 10, 25, { label: 'All', value: -1 }]}
                    colSpan={3}
                    count={users.length}
                    rowsPerPage={itemssPerPage}
                    page={page}
                    SelectProps={{
                        inputProps: {
                        'aria-label': 'rows per page',
                        },
                        native: true,
                    }}
                    onPageChange={handleChangePage}
                    onRowsPerPageChange={handleChangeRowsPerPage}
                    ActionsComponent={TablePaginationActions}
                    />
                </TableRow>
                </TableFooter>
            </Table>
        </TableContainer>
    )
}

export default UserList