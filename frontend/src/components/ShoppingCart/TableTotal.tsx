import { TableRow, TableCell } from '@mui/material'
import React, { useMemo } from 'react'
import ShoppingCart from '../../types/ShoppingCart'

interface TableTotalProps {
    shoppingCart: ShoppingCart
}
const TableTotal = ({shoppingCart}: TableTotalProps) => {
    const formatNumbers = (amount: number) => `${amount.toFixed(2)}`
    const totalPrice = useMemo(() => {
        return shoppingCart.productsInCart.reduce((a, b) => a + b.product.price * b.amount, 0)
    }, [shoppingCart])
    const countVat = () => totalPrice * 24 / 124
    return (
        <>
            <TableRow>
                <TableCell rowSpan={3} />
                <TableCell colSpan={3}>Subtotal</TableCell>
                <TableCell align="right">{formatNumbers(totalPrice - countVat())}</TableCell>
            </TableRow>
            <TableRow>
                <TableCell >Tax</TableCell>
                <TableCell colSpan={2} align="right">24 %</TableCell>
                <TableCell align="right">{formatNumbers(countVat())}</TableCell>
            </TableRow>
            <TableRow>
                <TableCell colSpan={3}>Total</TableCell>
                <TableCell align="right">{formatNumbers(totalPrice)}</TableCell>
            </TableRow>
        </>
    )
}

export default TableTotal