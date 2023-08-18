import { useEffect, useState } from 'react'
import { TableContainer, Paper, Table, TableBody, TableFooter, TableRow, TablePagination, TableCell, Button } from '@mui/material'
import TablePaginationActions from '@mui/material/TablePagination/TablePaginationActions'

import useAppSelector from '../../hooks/useAppSelector'
import ProductRow from './ProductRow'
import AddNewProduct from './AddNewProduct'
import useAppDispatch from '../../hooks/useAppDispatch'
import { initializeProductNotifications } from '../../redux/reducers/productsReducer'
import Notification from '../Notification'

const ProductsListDashboard = () => {
    const [page, setPage] = useState(0)
    const dispatch = useAppDispatch()
    const [itemssPerPage, setUsersPerPage] = useState(10)
    const { isCreateSuccess, products } = useAppSelector(state => state.productsReducer)
    const emptyRows = page > 0 ? Math.max(0, (1 + page) * itemssPerPage - products.length) : 0
    const [isVisible, setVisible] = useState(false)
    useEffect(() => {
        setVisible(false)
        dispatch(initializeProductNotifications)
    }, [isCreateSuccess])
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
    const handleModalClick = () => setVisible(state => !state)
    return (
        <TableContainer className='adminTable' sx={{
            padding: '3em 1em',
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center'
            }} 
            component={Paper}>
            {isCreateSuccess && <Notification message='Product created successfully!' severity='success' type='product'/>}
            <Button 
            variant='outlined'
            color='secondary'
            sx={{
                marginBottom: '2em' 
            }}
            onClick={handleModalClick}
            >Add a new product</Button>
            <AddNewProduct isVisible={isVisible} setVisible={setVisible} />
            <Table sx={{ minWidth: 500 }} aria-label="custom pagination table">
                <TableBody>
                    {(itemssPerPage > 0
                    ? products.slice(page * itemssPerPage, page * itemssPerPage + itemssPerPage)
                    : products
                 ).map(product => <ProductRow key={product.id} product={product}/>)}
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
                        count={products.length}
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

export default ProductsListDashboard