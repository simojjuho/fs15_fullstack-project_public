import Category from "./Category"

interface Product {
    id: string
    title: string
    price: number
    description: string
    inventory: number,
    productCategory: Category
}

export default Product