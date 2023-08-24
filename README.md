# Fullstack project

## List of contents

1. [Description](#description)
2. [Backend API endpoints](#backend-api-endpoints)
3. [Backend packages](#backend-packages)
4. [Frontend packages](#frontend-packages)
5. [Product tree](#product-tree)
6. [Deployment](#deployment)

## Description

This project is made as a final project for Integrify Finland's Fullstack Academy (Microsoft stack) backend module. It conssts of two separate projects, frontend and backend of which backend has been programmed using C# / ASPNET Core. The database, is built using Entity Framework Core model builder. It's purpose is to offer a RESTFUL Api endpoint for a webshop platform. Postgres database has been made using EF Core and the frontend side has been coded with React/TypeScript. It is the same one I used for my frontend project, that one you'll find from [here](https://github.com/simojjuho/fs15_frontend-project_public), and its deployment [here](https://bucolic-praline-32e73e.netlify.app/).

At the moment the user is able to add products and categories as an admin. As a customer the user is able to sign up and add products in the shoppng cart. In the future the user will also be able to make purchases (functionality already on the backend side has been made). Also adding images for the project (products and categories by the admin, users by the users themselves) is also coming in the near future.

## Backend API endpoints

The most up-to-date API Endpoint documentation can be found [here](https://fs15-webshop-js.azurewebsites.net/swagger/index.html)

## Backend packages
- AutoMapper.Extensions.Microsoft.DependencyInjection Version 12.0.1
- EFCore.NamingConventions Version 7.0.2
- Microsoft.AspNetCore.Authentication.JwtBearer Version 7.0.10
- Microsoft.AspNetCore.OpenApi Version 7.0.10
- Microsoft.EntityFrameworkCore Version 7.0.10
- Microsoft.EntityFrameworkCore.Design Version 7.0.10
- Npgsql.EntityFrameworkCore.PostgreSQL Version 7.0.4
- Swashbuckle.AspNetCore Version 6.5.0
- Swashbuckle.AspNetCore.Filters Version 7.0.8

## Frontend packages
- @emotion/react: ^11.11.0
- @emotion/styled: ^11.11.0
- @hookform/resolvers: "^3.1.0
- @mui/icons-material: ^5.11.16
- @mui/material: ^5.13.0
- @reduxjs/toolkit: ^1.9.3
- @testing-library/jest-dom: "^5.16.5
- @testing-library/react: "^13.4.0
- @testing-library/user-event: ^14.4.3
- @types/jest: ^27.5.2
- @types/node: ^17.0.45
- @types/react: ^18.0.33
- @types/react-dom ^18.0.11
- axios: ^1.4.0
- msw: ^1.2.1
- react: ^18.2.0
- react-dom: ^18.2.0
- react-hook-form: ^7.43.9
- react-redux: ^8.0.5
- react-router-dom: ^6.11.1
- react-scripts: 5.0.1
- sass: ^1.61.0
- typescript: ^4.9.5
- web-vitals: ^2.1.4
- yup: ^1.1.1

## Product tree

This project on the backend side is implementing CLEAN architecture. The layers are the following:
1. Core
2. Business
3. Controllers
4. Infrastructure

The core layer consists of the core entities, their abstractions and the abstractions of the repositories on the Infrastructure layer.

Business layer is the one holding all the actual logic how the backend functions. It maps all the base entities to DTOs and vice versa. It also checks if the user credentials are correct etc. It also creates the core entities and sends them to the repositories that save them to the database.

Controllers layer only holds the Controllers, the API Endpoints. They only pass data they get from the client straight to the corresponding service.

Infrastructure is the layer gathering all the threads together, registering services and makes the actual application. It also holds the implementations of all the repositories and database context, as is the best practice for CLEAN architecture.

```
.
├── backend
│   ├── planning
│   │   ├── api_and_entity_planning.pdf
│   │   ├── e_commerce_erd.pdf
│   │   ├── Endpoints
│   │   │   ├── auth.md
│   │   │   ├── categories.md
│   │   │   ├── images.md
│   │   │   ├── products.md
│   │   │   ├── purchases.md
│   │   │   └── users.md
│   │   └── UseCases
│   │       ├── Categories.md
│   │       ├── Images.md
│   │       ├── Orders.md
│   │       ├── Products.md
│   │       └── Users.md
│   ├── WebShopBackend.Business
│   │   ├── src
│   │   │   ├── Abstractions
│   │   │   │   ├── IAuthService.cs
│   │   │   │   ├── IBaseService.cs
│   │   │   │   └── IUserService.cs
│   │   │   ├── AutoMapperProfile.cs
│   │   │   ├── DTOs
│   │   │   │   ├── AddressDto
│   │   │   │   │   ├── AddressCreateDto.cs
│   │   │   │   │   ├── AddressGetDto.cs
│   │   │   │   │   └── AddressUpdateDto.cs
│   │   │   │   ├── OrderDto
│   │   │   │   │   ├── OrderCreateDto.cs
│   │   │   │   │   ├── OrderGetDto.cs
│   │   │   │   │   ├── OrderProductDto.cs
│   │   │   │   │   └── OrderUpdateDto.cs
│   │   │   │   ├── ProductCategoryDto
│   │   │   │   │   ├── ProductCategoryCreateDto.cs
│   │   │   │   │   ├── ProductCategoryGetDto.cs
│   │   │   │   │   └── ProductCategoryUpdateDto.cs
│   │   │   │   ├── ProductDto
│   │   │   │   │   ├── ProductCreateDto.cs
│   │   │   │   │   ├── ProductGetDto.cs
│   │   │   │   │   └── ProductUpdateDto.cs
│   │   │   │   ├── ReviewDto.cs
│   │   │   │   └── UserDto
│   │   │   │       ├── UserCreateDto.cs
│   │   │   │       ├── UserCredentials.cs
│   │   │   │       ├── UserGetDto.cs
│   │   │   │       └── UserUpdateDto.cs
│   │   │   ├── Services
│   │   │   │   ├── AddressService.cs
│   │   │   │   ├── BaseService.cs
│   │   │   │   ├── OrderService.cs
│   │   │   │   ├── ProductCategoryService.cs
│   │   │   │   ├── ProductService.cs
│   │   │   │   └── UserService.cs
│   │   │   └── Shared
│   │   │       ├── AuthService.cs
│   │   │       ├── CustomException.cs
│   │   │       ├── EnttiyIterator.cs
│   │   │       └── PasswordService.cs
│   │   └── WebShopBackend.Business.csproj
│   ├── WebShopBackend.Controllers
│   │   ├── src
│   │   │   └── Controllers
│   │   │       ├── AddressController.cs
│   │   │       ├── AuthController.cs
│   │   │       ├── CrudController.cs
│   │   │       ├── OrderController.cs
│   │   │       ├── ProductCategoryController.cs
│   │   │       ├── ProductController.cs
│   │   │       └── UserController.cs
│   │   └── WebShopBackend.Controllers.csproj
│   ├── WebShopBackend.Core
│   │   ├── src
│   │   │   ├── Abstractions
│   │   │   │   ├── CoreEntities
│   │   │   │   │   ├── IAddress.cs
│   │   │   │   │   ├── IBaseEntity.cs
│   │   │   │   │   ├── IOrder.cs
│   │   │   │   │   ├── IOrderProduct.cs
│   │   │   │   │   ├── IProductCategory.cs
│   │   │   │   │   ├── IProduct.cs
│   │   │   │   │   ├── IReview.cs
│   │   │   │   │   └── IUser.cs
│   │   │   │   └── Repositories
│   │   │   │       ├── IBaseRepository.cs
│   │   │   │       ├── IOrderProductRepository.cs
│   │   │   │       └── IUserRepository.cs
│   │   │   ├── Entities
│   │   │   │   ├── Address.cs
│   │   │   │   ├── Order.cs
│   │   │   │   ├── OrderProduct.cs
│   │   │   │   ├── ProductCategory.cs
│   │   │   │   ├── Product.cs
│   │   │   │   ├── Review.cs
│   │   │   │   └── User.cs
│   │   │   ├── Enums
│   │   │   │   ├── OrderProductsFilterBy.cs
│   │   │   │   ├── OrderStatus.cs
│   │   │   │   └── UserRole.cs
│   │   │   └── HelperClasses
│   │   │       ├── OrderProductQuery.cs
│   │   │       └── QueryOptions.cs
│   │   └── WebShopBackend.Core.csproj
│   ├── WebShopBackend.Infrastructure
│   │   ├── appsettings.Development.json
│   │   ├── appsettings.json
│   │   ├── Migrations
│   │   │   ├── 20230823142916_EnumEditing.cs
│   │   │   ├── 20230823142916_EnumEditing.Designer.cs
│   │   │   ├── 20230823143036_EnumEditing2.cs
│   │   │   ├── 20230823143036_EnumEditing2.Designer.cs
│   │   │   └── DatabaseContextModelSnapshot.cs
│   │   ├── Program.cs
│   │   ├── Properties
│   │   │   └── launchSettings.json
│   │   ├── src
│   │   │   ├── AuthorizationRequirements
│   │   │   │   ├── OwnerOnlyGetDto.cs
│   │   │   │   └── OwnerOnlyOrderUpdateDto.cs
│   │   │   ├── Database
│   │   │   │   ├── DatabaseContext.cs
│   │   │   │   └── TimeStampInterceptor.cs
│   │   │   ├── Middleware
│   │   │   │   └── ErrorHandler.cs
│   │   │   └── Repositories
│   │   │       ├── AddressRepository.cs
│   │   │       ├── BaseRepository.cs
│   │   │       ├── OrderProductRepository.cs
│   │   │       ├── OrderRepository.cs
│   │   │       ├── ProductCategoryRepository.cs
│   │   │       ├── ProductRepository.cs
│   │   │       └── UserRepository.cs
│   │   └── WebShopBackend.Infrastructure.csproj
│   ├── WebShopBackend.sln
│   ├── WebShopBackend.sln.DotSettings.user
│   └── WebShopBackend.Testing
│       ├── src
│       │   ├── Business
│       │   │   ├── Helpers
│       │   │   │   └── EntityIteratorTests.cs
│       │   │   └── Services
│       │   │       └── OrderServiceTests.cs
│       │   └── HelperMethods
│       │       └── TestHelper.cs
│       ├── Usings.cs
│       └── WebShopBackend.Testing.csproj
├── frontend
│   ├── amountOfCompomnents.txt
│   ├── package.json
│   ├── package-lock.json
│   ├── planning
│   │   ├── color_theme_planning.md
│   │   ├── requirements.md
│   │   ├── site_plan.md
│   │   └── type_planning.md
│   ├── README.md
│   ├── src
│   │   ├── App.tsx
│   │   ├── components
│   │   │   ├── AddInCart.tsx
│   │   │   ├── AdminDashboard
│   │   │   │   ├── AddNewCategory.tsx
│   │   │   │   ├── AddNewProduct.tsx
│   │   │   │   ├── CategoryList.tsx
│   │   │   │   ├── CategoryRow.tsx
│   │   │   │   ├── ProductRow.tsx
│   │   │   │   ├── ProductsListDashboard.tsx
│   │   │   │   ├── UserList.tsx
│   │   │   │   └── UserRow.tsx
│   │   │   ├── AmountInput.tsx
│   │   │   ├── CartEmpty.tsx
│   │   │   ├── Footer.tsx
│   │   │   ├── Header.tsx
│   │   │   ├── LandingPage
│   │   │   │   ├── LandingLoggedIn.tsx
│   │   │   │   └── LandingNotLogged.tsx
│   │   │   ├── Loading.tsx
│   │   │   ├── Notification.tsx
│   │   │   ├── ProductAmountUpdate.tsx
│   │   │   ├── ProductsPage
│   │   │   │   └── ProductOnGrid.tsx
│   │   │   ├── ProfileModals
│   │   │   │   ├── LoginModal.tsx
│   │   │   │   ├── LoginSuccess.tsx
│   │   │   │   ├── LoginTextfields.tsx
│   │   │   │   └── RegisterModal.tsx
│   │   │   ├── ProtectedRoute.tsx
│   │   │   ├── ShoppingCart
│   │   │   │   ├── ShoppingCartRow.tsx
│   │   │   │   └── TableTotal.tsx
│   │   │   └── SingleProduct
│   │   │       ├── ProductEdit.tsx
│   │   │       └── ProductNoEdit.tsx
│   │   ├── hooks
│   │   │   ├── useAppDispatch.ts
│   │   │   ├── useAppSelector.ts
│   │   │   ├── useDebounce.ts
│   │   │   ├── useFileInput.ts
│   │   │   └── useInput.ts
│   │   ├── index.tsx
│   │   ├── pages
│   │   │   ├── AdminPage.tsx
│   │   │   ├── ErrorPage.tsx
│   │   │   ├── HomePage.tsx
│   │   │   ├── LandingPage.tsx
│   │   │   ├── ProductsPage.tsx
│   │   │   ├── ShoppingCartPage.tsx
│   │   │   ├── SingleProductPage.tsx
│   │   │   └── UserProfilePage.tsx
│   │   ├── react-app-env.d.ts
│   │   ├── redux
│   │   │   ├── reducers
│   │   │   │   ├── categoryReducer.ts
│   │   │   │   ├── modalReducer.ts
│   │   │   │   ├── productsReducer.ts
│   │   │   │   ├── shoppingCartReducer.ts
│   │   │   │   └── userReducer.ts
│   │   │   └── store.ts
│   │   ├── reportWebVitals.ts
│   │   ├── setupTests.ts
│   │   ├── style
│   │   │   └── style.scss
│   │   ├── themes
│   │   │   └── globalTheme.ts
│   │   ├── types
│   │   │   ├── CategoryCreate.ts
│   │   │   ├── CategoryRemoveResponse.ts
│   │   │   ├── Category.ts
│   │   │   ├── ColorThemeChange.ts
│   │   │   ├── LoginCredentials.ts
│   │   │   ├── NewProductData.ts
│   │   │   ├── NewProduct.ts
│   │   │   ├── NewUser.ts
│   │   │   ├── ProductDataForUpdate.ts
│   │   │   ├── ProductPropertiesForUpdate.ts
│   │   │   ├── ProductsInCart.ts
│   │   │   ├── Product.ts
│   │   │   ├── Purchase.ts
│   │   │   ├── ShoppingCart.ts
│   │   │   ├── UserGet.ts
│   │   │   └── User.ts
│   │   ├── utils
│   │   │   ├── ColorThemeContext.tsx
│   │   │   ├── fileUploadService.ts
│   │   │   ├── fileUpload.ts
│   │   │   ├── isAdmin.ts
│   │   │   └── isProductInCart.ts
│   │   └── validation
│   │       ├── categoryCreationSchema.ts
│   │       ├── productCreationSchema.ts
│   │       └── registrationFormSchema.ts
│   └── tsconfig.json
└── README.md

```

## Deployment

The app has been deployed. You can try to use it on Netlify [here](https://famous-genie-277f21.netlify.app/). The backend has been deployed on Azure as well as the Postgres database. They are working on cheap services, which mich result in lag but they should be working.

If you want to use the app, there is a user profile set up with admin privileges: juho@mail.com with password juho123. Customer profiles you may make by yourself.


## Contact

If there is anything you would like to ask:

juho . simojoki [ the symbol that is in emails ] outlook . com