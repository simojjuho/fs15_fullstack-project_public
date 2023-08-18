import Product from "../types/Product"
import ProductInCart from "../types/ProductsInCart"
import ShoppingCart from "../types/ShoppingCart"

const isProductInCart = (shoppingCart: ShoppingCart, product: Product) =>
    shoppingCart.productsInCart.some((item: ProductInCart) => item.product.title === product.title)

    export default isProductInCart