import React from 'react'
import ProductInCart from '../../types/ProductsInCart'
import { TableCell, TableRow } from '@mui/material'
import ProductAmountUpdate from '../ProductAmountUpdate'

interface ShoppingCartRowProps {
  productInCart: ProductInCart
}
const ShoppingCartRow = ({productInCart}: ShoppingCartRowProps) => {
  return (
    <TableRow>
        <TableCell >{productInCart.product.id}</TableCell>
        <TableCell >{productInCart.product.title}</TableCell>
        <TableCell align="right" >
          <ProductAmountUpdate product={productInCart.product}/>
        </TableCell>
        <TableCell>
          {productInCart.product.price}
        </TableCell>
        <TableCell align="right">
          {productInCart.amount * productInCart.product.price}
        </TableCell>
    </TableRow>
  )
}

export default ShoppingCartRow