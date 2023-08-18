# Initial plan of the site structure

CommonAppBar
- Login button if not logged in
- user button if logged in
    - menu with logout and profile page
- search bar on products page
- header navi
- theme switch ('light'/'dark')

CommonFooter
- footer navi
- store logo

LandingPage
- Link to actual web store
- Some lorem ipsum etc
- path: ''

LoadingPage
- Visible when loading Products page

Error Page
- When going to wrong address

ProductsPage
- Products grid (user can set number of products visible)
- All products on the grid have:
    - picture (a link to product page)
    - price
    - add to cart (amount?)
- Sort products by price (or name?)
- - path: '/webshop'

SingleProductPage
- product picture (larger, variatoins?)
- product details on table
- price
- add to cart button (how many?)
- back button
- '/products/:id'

ShoppingCartPage
- list of the items on shopping cart
- proceed to checkout
- remove items (button visible on hover)
- change amount of items
- - path: '/users/:id/cart/:id'

UserProfilePage
- only visible for the user
- user details visible
- picture?
- remove account?
- purchase history
- path: '/users/:id

SinglePurchaseHistory (is time)
- list of items on purchase
- purchase price and date visible
- only visible for the customer who made the purchase
- path: '/users/:id/purchases/:id 
