import { useMemo, useState } from 'react'
import { createTheme, PaletteMode, ThemeProvider } from '@mui/material'
import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import { StyledEngineProvider } from '@mui/material/styles'

import HomePage from './pages/HomePage'
import ErrorPage from './pages/ErrorPage'
import LandingPage from './pages/LandingPage'
import ProductsPage from './pages/ProductsPage'
import SingleProductPage from './pages/SingleProductPage'
import UserProfilePage from './pages/UserProfilePage'
import ShoppingCartPage from './pages/ShoppingCartPage'
import './style/style.scss'
import customTheme from './themes/globalTheme'
import ColorThemeContext from './utils/ColorThemeContext'
import AdminPage from './pages/AdminPage'
import ProtectedRoute from './components/ProtectedRoute'


const router = createBrowserRouter([
  {
    path: '/',
    element: <HomePage />,
    errorElement: <ErrorPage />,
    children: [
      {
        path: '/',
        element: <LandingPage />
      },
      {
        path: 'products',
        element: <ProductsPage />
      },
      {
        path: 'products/:id',
        element: <SingleProductPage />
      },
      {
        path: 'users/profile',
        element: <UserProfilePage />
      },
      {
        path: 'shopping-cart',
        element: <ShoppingCartPage />
      },
      {
        path: 'admin-dashboard',
        element: <ProtectedRoute Component={AdminPage}/>
      }
    ]
  }
])

const App = () => {
  const [mode, setMode] = useState<PaletteMode>('light')
  
  const colorMode = () => setMode((prevMode: PaletteMode) => 
        prevMode === 'light' ? 'dark' : 'light'
        )

  const theme = useMemo(() => createTheme(customTheme(mode)),[mode])
  return (
    <StyledEngineProvider injectFirst>
      <ColorThemeContext.Provider value={colorMode} >
        <ThemeProvider theme={theme}>
          <RouterProvider  router={router}/>
        </ThemeProvider>
      </ColorThemeContext.Provider>
    </StyledEngineProvider>
  )
}

export default App