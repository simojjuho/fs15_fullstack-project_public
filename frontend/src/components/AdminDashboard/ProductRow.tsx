import { useMemo } from 'react'
import { useNavigate } from 'react-router-dom'
import { TableRow, TableCell, Avatar, Icon, Tooltip } from '@mui/material'
import ClearIcon from '@mui/icons-material/Clear'
import ArrowForwardIos from '@mui/icons-material/ArrowForwardIos'


import Product from '../../types/Product'
import useAppDispatch from '../../hooks/useAppDispatch'
import { removeProduct } from '../../redux/reducers/productsReducer'

interface ProductRowProps {
    product: Product
}
const ProductRow = ({ product }: ProductRowProps) => {
    const navigate = useNavigate()
    const dispatch = useAppDispatch()
    const handleRemoveClick = () => {
        dispatch(removeProduct(product.id))
    }
    const child = useMemo(() => {
        return (
            <TableRow className='itemRow' onClick={() => navigate(`/products/${product.id}`)}>
                <TableCell>
                    <Avatar src={product.images[1]} />
                </TableCell>
                <TableCell>{product.id}</TableCell>
                <TableCell>{product.title}</TableCell>
                <TableCell>
                    <Tooltip title='Proceed to product page to edit the product'>
                        <Icon>
                            <ArrowForwardIos color='secondary'/>
                        </Icon>
                    </Tooltip>
                </TableCell>
                <TableCell>
                    <Tooltip title='Remove product from the webshop'>
                        <Icon onClick={handleRemoveClick}>
                            <ClearIcon color='secondary'/>
                        </Icon>
                    </Tooltip>
                </TableCell>
            </TableRow>
        )        
    },[product])
    return (
        child
    )
}

export default ProductRow