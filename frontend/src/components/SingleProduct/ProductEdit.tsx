import { Box, Typography, TextField, Button } from '@mui/material'
import { useEffect } from 'react'

import Product from '../../types/Product'
import useInput from '../../hooks/useInput'
import useAppDispatch from '../../hooks/useAppDispatch'
import ProductPropertiesForUpdate from '../../types/ProductPropertiesForUpdate'
import useFileInput from '../../hooks/useFileInput'
import { initializeProductNotifications, updateProduct } from '../../redux/reducers/productsReducer'
import useAppSelector from '../../hooks/useAppSelector'
import Notification from '../Notification'

interface ProductEditProps {
    product: Product
    setEdit: React.Dispatch<React.SetStateAction<boolean>>
}
const ProductEdit = ({ product, setEdit }: ProductEditProps) => {
    const { isEditSuccess } = useAppSelector(state => state.productsReducer)
    const productsReducer = useAppSelector(state => state.productsReducer)
    const dispatch = useAppDispatch()
    useEffect(() => {
        if (isEditSuccess) setEdit(false)
        dispatch(initializeProductNotifications())
    }, [dispatch, isEditSuccess, setEdit])
    const titleInput = useInput()
    const priceInput = useInput()
    const categoryInput = useInput()
    const descriptionInput = useInput()
    const fileInput = useFileInput()
    const handleCancelClick = () => setEdit(state => !state)
    const handleSaveClick = () => {
        const formData: {file: File}[] = []
        const updateProps: ProductPropertiesForUpdate = {
            id: product.id,
            data: {}
        }
        if (fileInput.file) {
            for (let i = 0; i < fileInput.file.length; i++) {
                formData.push({file: fileInput.file[i]})
            }
            updateProps.images = formData
        }
        if (titleInput.value) updateProps.data.title = titleInput.value
        if (priceInput.value) updateProps.data.price = Number(priceInput.value)
        if (categoryInput.value) updateProps.data.category = Number(categoryInput.value)
        if (descriptionInput.value) updateProps.data.description = descriptionInput.value
        dispatch(updateProduct(updateProps))
    }
    const iterateFileList = () => {
        if (fileInput.file) {
            let  fileNames : {name: string, size: number}[] = []
            for (let i = 0; i < fileInput.file.length; i++) {
                fileNames.push({name: fileInput.file[i].name, size: fileInput.file[i].size})
            }
            return fileNames
        }
    }
    const handleRemoveClick = () => {
        fileInput.setFile(undefined)
    }
    return (
        <Box
            component="form"
            sx={{
                display: 'flex',
                flexDirection: 'column',
                gap: '1em'
            }}
        >
            <Typography variant='h3'>Edit product</Typography>
            {productsReducer.notification && !productsReducer.isEditSuccess && <Notification message={productsReducer.notification} severity={'error'} type='product'/>}
            <TextField color='secondary' type='text' {...titleInput} label={'Title'}/>
            <TextField color='secondary' type='number' {...priceInput} label={'Price'}/>
            <TextField color='secondary' type='number' {...categoryInput} label={'Category'}/>
            <TextField
                multiline
                rows={4}
                color='secondary'
                type='text'
                {...descriptionInput}
                label={'Description'}
            />
            {iterateFileList() &&<ul>
                Files to upload
                { iterateFileList()?.map(item =>
                <li key={item.size}>
                    {item.name} 
                </li>)}
            </ul>}
            {iterateFileList() && <Button onClick={handleRemoveClick} variant='outlined' color='secondary'>Remove Files</Button>}
            <Button
                variant="outlined"
                color='secondary'
                component="label"
                >
                Upload File
                <input
                    type="file"
                    hidden
                    multiple
                    onChange={e => fileInput.onChange(e)}
                />
            </Button>
            <Button onClick={handleSaveClick} variant='outlined' color='secondary'>Save</Button>
            <Button onClick={handleCancelClick} variant='outlined' color='secondary'>Cancel</Button>
        </Box>
    )
}

export default ProductEdit