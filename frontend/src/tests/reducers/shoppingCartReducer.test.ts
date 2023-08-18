import { addProduct, emptyShoppingCart, removeProduct, updateProduct } from "../../redux/reducers/shoppingCartReducer"
import initialProducts from "../data/products/initialProducts"
import store from "../shared/store"

beforeEach(() => {
    store.dispatch(emptyShoppingCart())
})

describe('testing shoppingCartReducer', () => {
    test('adding product succesfully', () => {
        for (let product of initialProducts) {
            store.dispatch(addProduct(product))
        }
        expect(store.getState().shoppingCartReducer.productsInCart).toHaveLength(3)
    })
    test('when adding two of same, the amount increases', () => {
        store.dispatch(addProduct(initialProducts[0]))
        store.dispatch(addProduct(initialProducts[0]))
        expect(store.getState().shoppingCartReducer.productsInCart).toHaveLength(1)
        expect(store.getState().shoppingCartReducer.productsInCart[0].amount).toBe(2)
    })
    test('removing a single product succesfully', () => {
        for (let product of initialProducts) {
            store.dispatch(addProduct(product))
        }
        expect(store.getState().shoppingCartReducer.productsInCart).toHaveLength(3)
        store.dispatch(removeProduct(1))
        const productsInCart = store.getState().shoppingCartReducer.productsInCart
        expect(productsInCart[0].product.title).not.toBe('Nike sneakers')

    })
    test('updating amount of products succesfully', () => {
        store.dispatch(addProduct(initialProducts[0]))
        store.dispatch(updateProduct({
            id: 1,
            amount: 4
        }))
        const amountOfProduct = store.getState().shoppingCartReducer.productsInCart[0].amount
        expect(amountOfProduct).toBe(4)
    })
})

export {}
