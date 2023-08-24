import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import axios, { AxiosError } from 'axios'
import Category from '../../types/Category'
import CategoryCreate from '../../types/CategoryCreate'
import CategoryRemoveResponse from '../../types/CategoryRemoveResponse'

const initialState: {
    categories: Category[]
    error: string
} = {
    categories: [],
    error: ''
}

export const getAllCategories = createAsyncThunk(
    'getAllCategories',
    async () => {
        try {
            const { data } = await axios.get<Category[]>('http://localhost:5093/api/v1/productcategorys')
            return data
        } catch (e) {
            const error = e as AxiosError
            return error.message
        }
    }
)
export const createCategory = createAsyncThunk(
    'createCategory',
    async (newCategory: CategoryCreate): Promise<Category | string> => {
        try {
            const access_token = window.localStorage.getItem('token')
            const { data } = await axios.post<Category>('http://localhost:5093/api/v1/productcategorys', newCategory, {
                headers: {
                    Authorization: `Bearer ${access_token}`
                }
            })
            return data
        } catch (e) {
            let error = e as AxiosError
            return error.message
        }
    }
)
export const removeCategory = createAsyncThunk(
    'removeCategory',
    async (id: string) => {
        try {
            const access_token = window.localStorage.getItem('token')
            const { data } = await axios.post<boolean>('http://localhost:5093/api/v1/productcategorys', id, {
                headers: {
                    Authorization: `Bearer: ${access_token}`
                }
            })
            if(data){
                return {
                    status: true,
                    id: id
                } as CategoryRemoveResponse
            }
        } catch (e) {
            const error = e as AxiosError
            return error.message
        }
    }
)
const categorySlice = createSlice({
    name: 'categories',
    initialState: initialState,
    reducers: {},
    extraReducers: (build) => {
        build.addCase(getAllCategories.fulfilled, (state, action) => {
            if(typeof action.payload === 'string') {
                return {
                    ...state,
                    error: action.payload
                }
            } else {
                return {
                    error: '',
                    categories: action.payload
                }
            }
        })
        build.addCase(createCategory.fulfilled, (state, action) => {
            if(typeof action.payload === 'string') {
                return {
                    ...state,
                    error: action.payload
                }
            } else {
                return {
                    error: '',
                    categories: state.categories.concat(action.payload)
                }
            }
        })
        build.addCase(removeCategory.fulfilled, (state, action) => {
            if(typeof action.payload === 'string') {
                return {
                    ...state,
                    error: action.payload
                }
            } else {
                const id = action.payload?.id
                return {
                    error: '',
                    categories: state.categories.filter(e => e.id != id)
                }
            }
        })
    }
})

const categoryReducer = categorySlice.reducer
export default categoryReducer
