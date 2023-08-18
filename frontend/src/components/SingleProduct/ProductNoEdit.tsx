import { Box, ImageList, ImageListItem, List, ListItem } from '@mui/material'

import Product from '../../types/Product'

interface ProductsNoEditProps {
    product: Product
}
const ProductsNoEdit = ({ product }: ProductsNoEditProps) => {
    return (
        <Box>
            <ImageList sx={{ width: 500 }} cols={3} rowHeight={164}>
              {product.images.map((item, index) => (
                <ImageListItem key={index}>
                  <img
                    src={`${item}`}
                    alt={product.title}
                    loading="lazy"
                  />
                </ImageListItem>
              ))}
            </ImageList>
            <List sx={{
              maxWidth: 500
            }}>
              <ListItem>Price: {product.price} €</ListItem>
              <ListItem>Category: {product.category.name}</ListItem>
              <ListItem>{product.description}</ListItem>
            </List>
        </Box>
    )
}

export default ProductsNoEdit