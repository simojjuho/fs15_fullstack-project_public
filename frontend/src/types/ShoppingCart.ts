import ProductsInCart from "./ProductsInCart"

interface ShoppingCart {
    id: string
    creationAt: string
    updateAt: string
    productsInCart: ProductsInCart[]
}

export default ShoppingCart