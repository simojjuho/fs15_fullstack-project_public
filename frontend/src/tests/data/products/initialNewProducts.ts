import NewProduct from "../../../types/NewProduct";

const initialProducts: NewProduct[] = [{
    title: 'Nike sneakers',
    price: 199.99,
    description: 'Cool sneakers!',
    images: ['firstImg.com', 'secondImg.fi'],
    categoryId: 1
},
{
    title: 'Adidas sneakers',
    price: 210.99,
    description: 'A bit better sneakers!',
    images: ['firstImg.com', 'secondImg.fi'],
    categoryId: 2,

},
{
    title: 'Reebok sneakers',
    price: 189.99,
    description: 'A bit worse sneakers!',
    images: ['firstImg.com', 'secondImg.fi'],
    categoryId: 3,
}
]

export default initialProducts