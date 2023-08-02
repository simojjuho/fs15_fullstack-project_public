# Product Use Cases from backend point of view

## Adding a product
1. Getting a POST request from the frontend to the API endpoint with ProductDto.
2. ProductsController
    - Role based authorization
3. -> ProductService
   - Map the ProductDto into a product
   - Save the CreationAt date
4. -> ProductRepository
   - Add the product
   - Save changes
5. Response with status code 200 and the product entity if successful

## Removing a product
1. Getting a DELETE request from the frontend to the API endpoint.
2. ProductsController
    - Role based authorization
    - Get the product id from the request query
3. -> ProductService
4. -> ProductRepository
    - Remove the product
    - Save changes
5. Response with status code 204 if successful

## Editing a product
1. Getting a PATCH request from the frontend to the API endpoint with ProductDto.
2. ProductsController
    - Role based authorization
    - Get the product id from the query
3. -> ProductService
    - Map the ProductDto into a product and save the product id
    - Save UpdateAt date
4. -> ProductRepository
    - Add the product
    - Save changes
5. Response with status code 200 and the product entity if successful