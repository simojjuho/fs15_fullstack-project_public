import { useMemo } from 'react'
import { IconButton, Tooltip } from '@mui/material'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart'
import RemoveShoppingCartIcon from '@mui/icons-material/RemoveShoppingCart'

import useAppDispatch from '../hooks/useAppDispatch'
import { removeProduct } from '../redux/reducers/shoppingCartReducer'
import { addProduct } from '../redux/reducers/shoppingCartReducer'
import Product from '../types/Product'
import isProductInCart from '../utils/isProductInCart'
import useAppSelector from '../hooks/useAppSelector'

interface AddInCartProps {
    product: Product
}
const AddInCart = ({ product }: AddInCartProps) => {
    const dispatch = useAppDispatch()
    const shoppingCart = useAppSelector(state => state.shoppingCartReducer)
    const productInCart = useMemo(() => {
        return isProductInCart(shoppingCart, product)
    }, [product, shoppingCart])
    const handleProductClick = () => {
        productInCart
        ? dispatch(removeProduct(product.id))
        : dispatch(addProduct(product))
    }
    return (
        <IconButton onClick={handleProductClick} sx={{
            color: 'secondary'
        }}>
            {productInCart
            ? <Tooltip title='Remove product from cart'><RemoveShoppingCartIcon /></Tooltip>
            : <Tooltip title='Add product in cart'><AddShoppingCartIcon /></Tooltip>}
        </IconButton>
    )
}

export default AddInCart