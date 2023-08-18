import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import axios, { AxiosError } from 'axios'

interface Category {
    id: number
    name: string
}
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
            const { data } = await axios.get<Category[]>('https://api.escuelajs.co/api/v1/categories')
            return data
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
    }
})

const categoryReducer = categorySlice.reducer
export default categoryReducer
