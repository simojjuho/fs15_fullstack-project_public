import { useContext, useState } from 'react'
import { Link as RouterLink, useNavigate } from 'react-router-dom'
import { AppBar, Toolbar, Typography, Box, IconButton, useTheme, Link, Menu, MenuItem } from '@mui/material'
import DarkModeIcon from '@mui/icons-material/DarkMode'
import LightModeIcon from '@mui/icons-material/LightMode'
import AccountCircleIcon from '@mui/icons-material/AccountCircle'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';

import ColorThemeContext from '../utils/ColorThemeContext'
import useAppSelector from '../hooks/useAppSelector'
import useAppDispatch from '../hooks/useAppDispatch'
import { logoutUser } from '../redux/reducers/userReducer'
import { setLoginVisibility, setRegistrationVisibility } from '../redux/reducers/modalReducer'

const Header = () => {
    const [anchorElUser, setAnchorElUser] = useState<null | HTMLElement>(null)
    const dispatch = useAppDispatch()
    const colorContext = useContext(ColorThemeContext)
    const theme = useTheme()
    const themeClickHandler = () => {
        if(colorContext) colorContext()
    }
    const shoppngCart = useAppSelector(state => state.shoppingCartReducer)
    const user = useAppSelector(state => state.userReducer.user)
    const userMenuItems = user ? ['Profile', 'Logout'] : ['Login', 'Sign up']
    if (user?.role === 'admin') userMenuItems.unshift('Admin dashboard')
    const navigate = useNavigate()
    const handleMenuItemClick = (action: string) => {
        switch (action) {
            case 'Logout':
                dispatch(logoutUser())
                handleCloseUserMenu()
                break
            case 'Profile':
                navigate(`/users/profile`)
                handleCloseUserMenu()
                break
            case 'Sign up':
                dispatch(setRegistrationVisibility())
                handleCloseUserMenu()
                break
            case 'Login':
                dispatch(setLoginVisibility())
                handleCloseUserMenu()
                break
            case 'Admin dashboard':
                navigate('/admin-dashboard')
                break
        }
    }
    const handleCloseUserMenu = () => {
        setAnchorElUser(null)
    }
    const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElUser(event.currentTarget);
    }
    return (
        <AppBar
            sx={{
            height: '80px',
            backgroundColor: 'secondary.main',
            }}
        >
            <Toolbar sx={{
            justifyContent: 'space-between'
            }}>
            <Link variant='body2' component={RouterLink} to='/' underline="none">
                <Typography
                    variant='h1'
                    color={'info.light'}
                >
                    NETSHOP
                </Typography>
            </Link>
            <Box role='navigation' sx={{
                display: 'flex',
                alignItems: 'center',    
                gap: '1em'
            }} >          
                <Link variant='body2' component={RouterLink} to='/' underline="none">
                    HOME
                </Link>
                <Link variant='body2' component={RouterLink} to='/products' underline="none">
                    PRODUCTS
                </Link>
                <Box sx={{position: 'relative'}}>
                    <IconButton aria-label='link to shopping cart' onClick={() => navigate('/shopping-cart')}>
                        <ShoppingCartIcon/>
                    </IconButton>
                    <Box sx={{
                        fontSize: '0.6em',
                        fontWeight: '700',
                        backgroundColor: 'orange',
                        width: '1.6em',
                        height: '1.6em',
                        borderRadius: '50%',
                        position: 'absolute',
                        top: '10%',
                        right: '20%',
                        display: 'flex',
                        justifyContent: 'center',
                        alignItems: 'center'
                    }}>{shoppngCart.productsInCart.length}</Box>
                </Box>
                <IconButton onClick={themeClickHandler} aria-label='color theme switch'>
                    {theme.palette.mode === 'light' ? <DarkModeIcon  /> : <LightModeIcon />}
                </IconButton>
                <IconButton onClick={handleOpenUserMenu}>
                    <AccountCircleIcon />
                </IconButton>
                <Menu
                    anchorEl={anchorElUser}
                    anchorOrigin={{
                      vertical: 'bottom',
                      horizontal: 'right',
                    }}
                    keepMounted
                    transformOrigin={{
                      vertical: 'top',
                      horizontal: 'right',
                    }}
                    open={Boolean(anchorElUser)}
                    onClose={handleCloseUserMenu}
                >
                    {userMenuItems.map((item) => (
                    <MenuItem key={item} onClick={() => handleMenuItemClick(item)}>
                        <Typography textAlign="center">{item}</Typography>
                    </MenuItem>
              ))}
                </Menu>
            </Box>
            </Toolbar>
        </AppBar>
    )
    }

export default Header