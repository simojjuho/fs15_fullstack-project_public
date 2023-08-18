import { yupResolver } from "@hookform/resolvers/yup"
import { Button, Dialog, DialogActions, DialogContent, TextField } from "@mui/material"
import { useEffect } from "react"
import { Controller, useForm } from "react-hook-form"

import productCreationSchema, { ProductCreationData } from "../../validation/productCreationSchema"
import useAppDispatch from "../../hooks/useAppDispatch"
import useFileInput from "../../hooks/useFileInput"
import fileUploadService from "../../utils/fileUploadService"
import { createProduct, initializeProductNotifications } from "../../redux/reducers/productsReducer"
import NewProductData from "../../types/NewProductData"
import useAppSelector from "../../hooks/useAppSelector"
import Notification from "../Notification"

interface AddNewProductProps {
    isVisible: boolean
    setVisible: React.Dispatch<React.SetStateAction<boolean>>
}
const AddNewProduct = ({isVisible, setVisible}: AddNewProductProps) => {
    const handleModalClose = () => setVisible(false)
    const dispatch = useAppDispatch()
    const { isCreateSuccess, notification} = useAppSelector(state => state.productsReducer)
    const { handleSubmit, control, formState: { errors }, reset } = useForm<ProductCreationData>({
        defaultValues: {
            title: '',
            price: 0,
            category: 1,
            description: ''
        },
        resolver: yupResolver(productCreationSchema)
    })
    const fileInput = useFileInput()
    useEffect(() => {
        reset()
    }, [dispatch, isVisible, reset])
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
    const onSubmit = async (data: ProductCreationData) => {
        const images: {file: File}[] = []
        if (fileInput.file) {
            for (let i = 0; i < fileInput.file.length; i++) {
                images.push({file: fileInput.file[i]})
            }
        }
        const locations = await fileUploadService(images)
        const newProductData: NewProductData = {
            title: data.title,
            price: data.price,
            categoryId: data.category,
            description: data.description,
            images: locations
        }
        dispatch(createProduct(newProductData))
    }
    return (
        <Dialog open={isVisible} onClose={handleModalClose}>
            {!isCreateSuccess && notification && <Notification message={notification} severity='error' type='product' />}
            <DialogContent sx={{ display: 'flex', flexDirection: 'column'}}>
            <Controller 
                    name="title"
                    control={control}
                    rules={{ required: true }}
                    render={({ field }) => 
                        <TextField
                            { ...field }
                            placeholder='Product title'
                            label={errors.title?.message ? errors.title?.message : 'Title'} 
                            color={ errors.title?.message ? 'warning' : 'secondary' }
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="price"
                    control={control}
                    rules={{ required: true }}
                    render={({ field }) => 
                        <TextField
                            { ...field }
                            placeholder='Price'
                            type='number'
                            label={errors.price?.message ? errors.price?.message : 'Price'} 
                            color={ errors.price?.message ? 'warning' : 'secondary' }
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="category"
                    control={control}
                    rules={{ required: true }}
                    render={({ field }) => 
                        <TextField
                            { ...field }
                            placeholder='Category'
                            type='number'
                            label={errors.category?.message ? errors.category?.message : 'Category'} 
                            color={ errors.category?.message ? 'warning' : 'secondary' }
                            className='formInput'
                        />}           
                />
                <Controller 
                    name="description"
                    control={control}
                    rules={{ required: true }}
                    render={({ field }) => 
                        <TextField
                            { ...field }
                            placeholder='Description'
                            type='number'
                            multiline
                            rows={4}
                            label={errors.description?.message ? errors.description?.message : 'Description'} 
                            color={ errors.description?.message ? 'warning' : 'secondary' }
                            className='formInput'
                        />}           
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
                    className='formInput'
                    >
                    Upload File
                    <input
                        type="file"
                        hidden
                        multiple
                        onChange={e => fileInput.onChange(e)}
                    />
                </Button>
            </DialogContent>
            <DialogActions>
                <Button variant='outlined' color='secondary' onClick={handleSubmit(onSubmit)}>Add</Button>
                <Button variant='outlined' color='secondary' onClick={handleModalClose}>Cancel</Button>
            </DialogActions>
        </Dialog>
    )
}

export default AddNewProduct