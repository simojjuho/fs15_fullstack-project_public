import Product from "./Product"

interface Purchase{
    id: string
    purchaseDate: string
    purchasePrice: number
    products: Product[]
    customerId: string
}

export default Purchase