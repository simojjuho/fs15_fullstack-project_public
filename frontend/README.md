# Front-end Project
by Juho Simojoki

## Description
This project is an assignment for Integrify Finland's Full Stack Academy (Microsoft stack). It is a main project for the frontend module and it's it uses many pacjages and technologies used previously. This site is deployed on Netlify: [click here](https://bucolic-praline-32e73e.netlify.app/)

![React](https://img.shields.io/badge/React-v.18-blue)
![Redux toolkit](https://img.shields.io/badge/RTK-v.1-purple)
![TypeScript](https://img.shields.io/badge/TypeScript-v.4-green)
![SASS](https://img.shields.io/badge/SASS-v.1-hotpink)

Complete list of dependencies:
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

## Requirements

1. Use the API endpoint [https://fakeapi.platzi.com/](https://fakeapi.platzi.com/) to create an e-commerce website. Read the documentation and learn how to use the different endpoints.
2. Create at lease 4 pages (can be more if you want): Home page, product page,
profile page (only available if user logins), and cart page (cart could be a page or a modal)
3. Create Redux store for following features:
    - product reducer: get all products, find a single products, sort products by
    categories, sort products by price. Create, update and delete a product (enable update & delete features only for admin of the webapp. For example, you can check if user is your admin account before let them delete product)
    - user reducer: Register and Login
    - cart reducer: add product to cart, remove products, update products's quantity in cart
4. When adding routers to your application, programatically set certain routes to be private. For example, route to user profile page should not be accessible if user has not logged in.
5. Deploy the application and rewrite README file.

## Bonus

1. Use context API to switch theme
2. Implement unit testing for the reducers

## Instruction to start the project

The app is built with create react app so the basic commands:

### `npm install`

Install all the dependencies

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in the browser.

The page will reload if you make edits.\
You will also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.
