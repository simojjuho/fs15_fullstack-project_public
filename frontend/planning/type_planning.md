# Site type definiotions

At least following types can be identified:

<!-- Interface from the API -->
interface Product {
    id: number
    title: string
    price: number
    description: string
    images: string[] 
    creationAt: string
    updateAt: string
    category: Category
}
interface category: {
      id: number,
      name: CategoryName,
      image: string
    },
<!-- Initial plan -->
interface User {
    id: string
    username: string
    <!-- If this was not only frontend project, passwords would not be saved like this. -->
    password: string
    description: string
    address_1: string
    address_2: string
    postalCode: string
    city: string
    country: string
    phone: string
    role: Role
}
    
type Role = 'admin' | 'regular'
<!-- Initial plan -->
interface ShoppingCart {
    id: string
    creationAt: string
    updateAt: string
    userId: number
    productsInCart: ProductsInCart[]
}
interface ProductsInCart {
    amount: number
    product: Product
}
<!-- in case of single purchase page is made -->
interface Purchase{
    id: string
    purchaseDate: string
    purchasePrice: number
    products: Product[]
    customerId: string
}










<!-- 
    [{"id":28,"title":"Bespoke Wooden Chicken","price":396,"description":"Carbonite web goalkeeper gloves are ergonomically designed to give easy fit","images":["https://picsum.photos/640/640?r=7209","https://picsum.photos/640/640?r=7879","https://picsum.photos/640/640?r=598"],"creationAt":"2023-05-09T01:58:58.000Z","updatedAt":"2023-05-09T01:58:58.000Z","category":{"id":3,"name":"Furniture","image":"https://picsum.photos/640/640?r=2325","creationAt":"2023-05-09T01:58:58.000Z","updatedAt":"2023-05-09T01:58:58.000Z"}}
 -->