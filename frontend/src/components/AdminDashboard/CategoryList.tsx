import { useState } from 'react';
import { Button, Paper, Table, TableBody, TableCell, TableContainer, TableFooter, TablePagination, TableRow } from '@mui/material';
import TablePaginationActions from '@mui/material/TablePagination/TablePaginationActions';

import useAppSelector from '../../hooks/useAppSelector';
import CategoryRow from './CategoryRow';
import AddNewCategory from './AddNewCategory';

interface CategoryListProps {
}

const CategoryList = (props: CategoryListProps) => {
  const [isVisible, setVisible] = useState(false)
  const handleModalClick = () => setVisible(state => !state)
  const { categories } = useAppSelector(state => state.categoryReducer)
  const [page, setPage] = useState(0)
  const [itemssPerPage, setUsersPerPage] = useState(10)
  const emptyRows = page > 0 ? Math.max(0, (1 + page) * itemssPerPage - categories.length) : 0
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
    <TableContainer component={Paper} className='adminTable' sx={{
      padding: '3em 1em',
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center'
      }} >
      <Button 
      variant='outlined'
      color='secondary'
      sx={{
          marginBottom: '2em' 
      }}
      onClick={handleModalClick}
      >Add a new category</Button>
      <AddNewCategory isVisible={isVisible} setVisible={setVisible} />
      <Table sx={{ minWidth: 500 }} aria-label="custom pagination table">
        <TableBody>
            {(itemssPerPage > 0
            ? categories.slice(page * itemssPerPage, page * itemssPerPage + itemssPerPage)
            : categories
            ).map(category => <CategoryRow key={category.id} category={category}/>)}
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
            count={categories.length}
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
  );
}

export default CategoryList