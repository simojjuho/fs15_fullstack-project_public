# Order use cases

## Place an order
1. Getting a request to the orders API endpoint with a list of product ids and amounts
    - Also a user id, in the beginning only users logged in may place an order.
    - Orders must have an address_id (FIX THE ERD!)
    - User must be authenticated
2. OrderController
3. -> OrderService
   - Turn Order into OrdersProducts and an Order.
   - Check inventory, if there are enough of products in stock.
   - If not, response status that not enough of stock and the products that is out of stock.
   - Set order status to be 'received'
4. -> OrderRepository
   - Add the order
   - Save changes
5. -> OrderProductRepository
   - If previous is successful, add all the OrderProducts to the orders_products.
6. -> Response status code 201 if order successful

## Ship an order
1. Getting a PATCH request to the API endpoint
   - Uses role based authorization, 'admin' role required
2. OrderController
3. OrderService
   - Setting order status from 'received' to 'shipped'
4. Sending status code 204 as a response if successful


## Cancel an order
1. Getting a PATCH request to the API endpoint
   - Uses role based authorization, 'admin' role required
2. OrderController
3. OrderService
   - Setting order status to 'shipped' only if the order has not been shipped already.
4. Sending status code 204 as a response, if successful