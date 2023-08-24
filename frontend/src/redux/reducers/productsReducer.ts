import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import axios, { AxiosError } from 'axios'

import Product from "../../types/Product";
import ProductPropertiesForUpdate from "../../types/ProductPropertiesForUpdate";
import ProductDataForUpdate from "../../types/ProductDataForUpdate";
import fileUploadService from "../../utils/fileUploadService";
import NewProductData from "../../types/NewProductData";

const initialState: {
    loading: boolean,
    notification: string,
    isEditSuccess: boolean
    isCreateSuccess: boolean
    products: Product[]
} = {
    loading: false,
    notification: '',
    isEditSuccess: false,
    isCreateSuccess: false,
    products: []
}
export const getAllProducts = createAsyncThunk(
    'getAllProducts',
    async () => {
        try {
            const result = await axios.get<Product[]>('http://localhost:5093/api/v1/products')
            return result.data
        } catch (e) {
            let error = e as AxiosError
            return error
        }
    }
)
export const createProduct = createAsyncThunk(
    'createProduct',
    async (newProduct: NewProductData): Promise<Product | AxiosError> => {
        try {
            const access_token = window.localStorage.getItem('token')
            const result = await axios.post<Product>('http://localhost:5093/api/v1/products', newProduct, {
                headers: {
                    Authorization: `Bearer ${access_token}`
                }
            })
            return result.data
        } catch (e) {
            let error = e as AxiosError
            return error
        }
    }
)
export const removeProduct = createAsyncThunk(
    'removeProduct',
    async (id: string): Promise<{result: boolean, id: string} | AxiosError> => {
        try {
            const access_token = window.localStorage.getItem('token')
            const { data } = await axios.delete<boolean>(`http://localhost:5093/api/v1/products/${id}`, {
                headers: {
                    Authorization: `Bearer ${access_token}`
                }
            })
            return {result: data, id: id}
        } catch (e) {
            let error = e as AxiosError
            return error
        }
    }
)
export const updateProduct = createAsyncThunk(
    'updateProduct',
    async (newProps: ProductPropertiesForUpdate): Promise<Product | AxiosError> =>  {
        try {
            let dataForUpdate: ProductDataForUpdate
            /* if (newProps.images) {
                const fileData = await fileUploadService(newProps.images)
                console.log([...fileData])
                dataForUpdate = {
                    ...newProps.data,
                    images: [...fileData]
                }
                console.log(dataForUpdate)
            } else { */
                dataForUpdate = {
                    ...newProps.data
                //}
            }     
            const access_token = window.localStorage.getItem('token')
            const { data } = await axios.put<Product>(`http://localhost:5093/api/v1/products/${newProps.id}`, dataForUpdate, {
                headers: {
                    Authorization: `Bearer ${access_token}`
                }
            })
            return data
        } catch (e) {
            let error = e as AxiosError
            return error
        }
    }
)
const productsSlice = createSlice({
    name: 'productsReducer',
    initialState: initialState,
    reducers: {
        emptyProductsReducer: (state) => {
            return {
                ...state,
                products: []
            }
        },
        sortProductsByPrice: (state, action: PayloadAction<'desc' | 'asc'>) => {
            if (action.payload === 'desc') state.products.sort((a, b) => b.price-a.price)
            if (action.payload === 'asc') state.products.sort((a, b) => a.price-b.price)
        },
        initializeProductNotifications: (state) => {
            return {
                ...state,
                isEditSuccess: false,
                isCreateSuccess: false,
                notification: ''
            }
        }
    },
    extraReducers: (build) => {
        build
            .addCase(getAllProducts.fulfilled, (state, action) => {
                if(action.payload instanceof AxiosError) {
                    state.notification = action.payload.message
                } else {
                    state.products = action.payload
                }
                state.loading = false
            })
            .addCase(getAllProducts.pending, (state, action) => {
                state.loading = true
            })
            .addCase(getAllProducts.rejected, (state, action) => {
                state.loading = false
                state.notification = 'Cannot get data from the server'
            })
            .addCase(createProduct.fulfilled, (state, action) => {
                if(action.payload instanceof AxiosError) {
                    state.notification = action.payload.message
                } else {
                    state.products.push(action.payload)
                    state.isCreateSuccess = true
                }
                state.loading = false
            })
            .addCase(createProduct.pending, (state, action) => {
                state.loading = true
            })
            .addCase(createProduct.rejected, (state, action) => {
                state.loading = false
                state.notification = 'Could not create a new product'
            })
            .addCase(removeProduct.fulfilled, (state, action) => {
                if(action.payload instanceof AxiosError) {
                    state.notification = action.payload.message
                } else {
                    const { result, id } = action.payload
                    if (result) {
                        state.products = state.products.filter(item => item.id !== id)
                    } else {
                        state.notification = 'Could not remove the product'
                    }
                }
                state.loading = false
            })
            .addCase(removeProduct.pending, (state, action) => {
                state.loading = true
            })
            .addCase(removeProduct.rejected, (state, action) => {
                state.loading = false
                state.notification = 'Could not remove the product'
            })
            .addCase(updateProduct.fulfilled, (state, action) => {
                if(action.payload instanceof AxiosError) {
                    state.notification = action.payload.message
                } else {
                    const product = action.payload
                    return {
                        ...state,
                        isEditSuccess: true,
                        products: state.products.map(item => item.id === product.id ? product : item)
                    }
                }
                state.loading = false
            })
            .addCase(updateProduct.pending, (state, action) => {
                state.loading = true
            })
            .addCase(updateProduct.rejected, (state, action) => {
                state.loading = false
                state.notification = 'Could not update the product'
            })
        }
})

export const { emptyProductsReducer, sortProductsByPrice, initializeProductNotifications } = productsSlice.actions
const productsReducer = productsSlice.reducer
export default productsReducer