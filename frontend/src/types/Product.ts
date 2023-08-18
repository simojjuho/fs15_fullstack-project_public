import Category from "./Category"

interface Product {
    id: number
    title: string
    price: number
    description: string
    images: string[] 
    creationAt: string
    updateAt?: string
    category: Category
}

export default Product