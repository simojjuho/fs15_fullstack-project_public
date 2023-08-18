import { Box } from '@mui/material'

import AmountInput from './AmountInput'
import ProductInCart from '../types/ProductsInCart'
import useAppDispatch from '../hooks/useAppDispatch'
import useAppSelector from '../hooks/useAppSelector'
import useInput from '../hooks/useInput'
import { updateProduct, removeProduct } from '../redux/reducers/shoppingCartReducer'
import Product from '../types/Product';
import AddInCart from './AddInCart'
import isProductInCart from '../utils/isProductInCart'

interface ProductAmountUpdateProps{
    product: Product
}
const ProductAmountUpdate = ({product}: ProductAmountUpdateProps) => {
    const shoppingCart = useAppSelector(state => state.shoppingCartReducer)
    const dispatch = useAppDispatch()
    const initialAmount = () => {
        const item = shoppingCart.productsInCart.find(item => item.product.id === product.id)
        if (item) return `${item.amount}`
        return '1'
        }
    const { value, onChange } = useInput(initialAmount())
    const handleUpdate = () => {
        const amount = Number(value)
        if( typeof amount === 'number' ) {
            amount === 0 
            ? dispatch(removeProduct(product.id))
            : dispatch(updateProduct({id: product.id, amount}))
        }        
    }
    
    return (
        <Box sx={{
            display: 'flex',
            flexDirection: 'row',
            justifyContent: 'end',
            gap: 1
        }}>
            {isProductInCart(shoppingCart, product) ? <AmountInput handleChange={onChange} handleUpdate={handleUpdate} initialValue={value}/> : null} 
            <AddInCart product={product}/>
        </Box>
    )
}

export default ProductAmountUpdate