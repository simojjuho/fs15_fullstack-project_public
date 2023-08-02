# Categories use cases
- All of the next use cases are using role based authorization and they require user role 'admin'

## Add a category
1. Get a request to the API endpoint with an object with
    - Array of image urls
    - Category name
    - Category description
2. CategoryController
3. CategoryService
    - Create Map Category instance out of CategoryDto
4. CategoryRepository
    - Add category and save changes
5. Send a status code 201 if successful.

## Edit a category (OPTIONAL)

## Remove a category (OPTIONAL)