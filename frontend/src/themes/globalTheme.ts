import { PaletteMode } from "@mui/material"


const customTheme = (mode: PaletteMode) => ({
    typography: {
        fontFamily: 'Poppins, sans-serif',
        fontWeight: '900',
        body1: {
            fontFamily: 'Poppins, sans-serif',
        },
        body2: {
            fontFamily: 'Poppins, sans-serif',
            fontWeight: '600'
        },
        h1: {
            fontFamily: 'Poppins, sans-serif',
            fontSize: '4em',
            fontWeight: '900'
            
        },
        h2: {
            fontFamily: 'Poppins'
        },
        h3: {
            fontFamily: 'Poppins',
            fontSize: '1.2em'
        }
    },
    palette: {
        mode,
        ...(mode === 'light'
        ? {
            primary: {
                main: '#FEFEFE',
                dark: '#e1dcd7'
            },
            secondary: {
                main: '#074a41',
            },
            info: {
                main: '#FEFEFE',
                dark: '#e1dcd7'
            }
        }
        : {
            primary: {
                light:'#2e5952',
                main: '#121212',
        },
            secondary: {
                main: '#090909',

            },
            info: {
                main: '#335555',
                
                
            }
        })
    },
})


export default customTheme

/* 
primaryColor1: #074a41 rgb(7, 74, 65)
primaryColor2: e1dcd7 rgb(225, 220, 215)
primaryColor3: #FFF  rgb(255, 255, 255)
secondaryColor: #000
complementaryColor1: #ffbab6 rgb(254, 252, 136)
complementaryColor2: #fe7f63 rgb(244, 74, 255)
 */