import { rest } from 'msw'
import { setupServer } from 'msw/node'

import { objectParser } from '../testUtils/parsers'
import Product from '../../types/Product'
import initialProducts from '../data/products/initialProducts'
import singleReadyProduct from '../data/products/singleReadyProduct'

let products: Product[] = initialProducts
let mutableProducts: Product[] = initialProducts
const productServer = setupServer(
    rest.get('https://api.escuelajs.co/api/v1/products', (req, res, ctx) => {
        mutableProducts = [...products]
        return res(
            ctx.json(products),
        )
    }),
    rest.post('https://api.escuelajs.co/api/v1/products', async (req, res, ctx) => {
        /* const data = await req.json()
        let newId = products[-1].id + 1
        if(!newId) newId = 1 
        const newProduct = objectParser(data, newId)
        mutableProducts.push(newProduct) */  
        return res(
            ctx.json(singleReadyProduct)   
        )              
    }),
    rest.delete('https://api.escuelajs.co/api/v1/products/:id', async (req, res, ctx) => {
        const id = Number(req.params.id)
        mutableProducts = products.filter(item => item.id !== id)
        return res(
            ctx.json(true)
        )
    }),
    rest.put('https://api.escuelajs.co/api/v1/products/:id', async (req, res, ctx) => {
        const product = mutableProducts[0]
        product.title = 'Under Armour sneakers'
        return res(
            ctx.json(product)
        )        
    })
)

export default productServer