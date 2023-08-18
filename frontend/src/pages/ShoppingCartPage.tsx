import { Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from '@mui/material'

import useAppSelector from '../hooks/useAppSelector'
import ShoppingCartRow from '../components/ShoppingCart/ShoppingCartRow'
import TableTotal from '../components/ShoppingCart/TableTotal'
import CartEmpty from '../components/CartEmpty'

const ShoppingCartPage = () => {
  const shoppingCart = useAppSelector(state => state.shoppingCartReducer)
  const productsInCart = shoppingCart.productsInCart
  if(productsInCart.length === 0) return <CartEmpty />

  return (
      <TableContainer component={Paper} sx={{
        padding: '6em 0',
        minHeight: '90vh'
      }}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell >Product ID</TableCell>
              <TableCell >Product name</TableCell>
              <TableCell >Amount</TableCell>
              <TableCell>á price</TableCell>
              <TableCell  align="right">Price</TableCell>
            </TableRow>          
          </TableHead>
          <TableBody>
            {productsInCart.map(product => <ShoppingCartRow key={product.product.id} productInCart={product}/>)}
            <TableTotal shoppingCart={shoppingCart}/>
          </TableBody>
        </Table>
    </TableContainer>
  )
}

export default ShoppingCartPage