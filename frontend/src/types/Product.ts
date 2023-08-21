import Category from "./Category"

interface Product {
    id: string
    title: string
    price: number
    description: string
    inventory: number,
    category: Category
}

export default Product