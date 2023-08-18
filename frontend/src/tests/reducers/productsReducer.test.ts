import { createProduct, removeProduct, getAllProducts, sortProductsByPrice, updateProduct } from "../../redux/reducers/productsReducer"
import singleProduct from "../data/products/singleInitialProduct"
import initialProducts from "../data/products/initialNewProducts"
import store from "../shared/store"
import productServer from "../servers/productsServer"
import ProductPropertiesForUpdate from "../../types/ProductPropertiesForUpdate"

beforeAll(() => {
    productServer.listen({
        onUnhandledRequest: 'error'
    })
})
afterAll(() => {
    productServer.close()
})
beforeEach(async () => {
    await store.dispatch(getAllProducts())
})
describe('testing productsReducer', () => {
    test('state is initialized and fetching products functions properly', async () => {
        const initializedState = store.getState().productsReducer
        expect(initializedState.loading).toBe(false)
        expect(initializedState.notification).toBeFalsy()
        expect(initializedState.products).toHaveLength(3)
    })
    //TODO: This needs to be fixed still
    test('creating new product entry', async () => {
        const newProduct = await store.dispatch(createProduct(singleProduct))
        expect(store.getState().productsReducer.products).toHaveLength(4)
        expect(newProduct.meta.arg.title).toBe('Puma sneakers')
    })
    test('removing a product is succesful', async () => {
        expect(store.getState().productsReducer.products).toHaveLength(3)
        await store.dispatch(removeProduct(2))
        expect(store.getState().productsReducer.products).toHaveLength(2)
    })
    test('products are sorted by price ascending', async () => {
        store.dispatch(sortProductsByPrice('asc'))
        expect(store.getState().productsReducer.products[0].title).toBe('Reebok sneakers')
        expect(store.getState().productsReducer.products[1].title).toBe('Nike sneakers')
        expect(store.getState().productsReducer.products[2].title).toBe('Adidas sneakers')
    })
    test('updating product succesfully', async () => {
        const updates: ProductPropertiesForUpdate = {
            id: 1,
            data: {
                title: 'Under Armour sneakers'
            }
        }
        await store.dispatch(updateProduct(updates))
        expect(store.getState().productsReducer.products[0].title).toBe('Under Armour sneakers')
    })
})
export {}

