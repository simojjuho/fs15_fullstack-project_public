import { useEffect, useState } from "react"
import { Box, Button, Container, Grid, Input, Pagination } from "@mui/material"
import ArrowDropDownIcon from '@mui/icons-material/ArrowDropDown'
import ArrowDropUpIcon from '@mui/icons-material/ArrowDropUp'

import useAppSelector from "../hooks/useAppSelector"
import ProductOnGrid from "../components/ProductsPage/ProductOnGrid"
import useDebounce from "../hooks/useDebounce"
import Product from "../types/Product"
import Loading from "../components/Loading"
import useAppDispatch from "../hooks/useAppDispatch"
import { sortProductsByPrice } from "../redux/reducers/productsReducer"

const ProductsPage = () => {
  const [page, setPage] = useState(1)
  const [itemOffset, setOffset] = useState(0)
  const [itemsPerPage, setItemsPerPage] = useState(12)
  const [priceSort, setPriceSort] = useState<boolean>(true)
  const [category, setCategory] = useState<string>('Show all')
  const { products, loading } = useAppSelector(state => state.productsReducer)
  const dispatch = useAppDispatch()
  useEffect(() => {
    if(products.length > 0) {
      setOffset((page - 1) * itemsPerPage % products.length)
    }
  }, [page])
  const { categories } = useAppSelector(state => state.categoryReducer)
  const categoryList = categories.map(item => item.name)
  categoryList.push('Show all')
  const handleCategoryClck = (item: string) => setCategory(item)
  const productsOfCategory = products.filter(item => category === 'Show all' ? item : item.category.name === category ? item : null)
  const filterFunc = (filter: string, products: Product[]): Product[] => {
    return products.filter(item => item.title.toLowerCase().includes(filter.toLowerCase()))
  }
  const searchDebounce = useDebounce<Product>(filterFunc, productsOfCategory)
  useEffect(() => {
    setPage(1)
  }, [searchDebounce.search, category])
  const pageCount = Math.ceil(searchDebounce.filteredItems.length / itemsPerPage)
  const endOffset = itemOffset+itemsPerPage
  const itemsToShow = searchDebounce.filteredItems.slice(itemOffset, endOffset)
  const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value)
  }
  if(loading) return <Loading />
  const sortByPriceHandler = () => {
    priceSort
    ? dispatch(sortProductsByPrice('asc'))
    : dispatch(sortProductsByPrice('desc')) 
    setPriceSort(state => !state)
  }
  return (
    <Container maxWidth='lg' sx={{
      padding: '6em 0',
      minHeight: '80vh',
      display: 'flex',
      flexDirection: 'column'
    }}>
      <Box sx={{ display: 'flex', gap: 2, marginBottom: 3}}>
        {categoryList.map(item => <Button onClick={() => handleCategoryClck(item)} variant='outlined' color='secondary' key={item}>{item}</Button>)}
      </Box>
      <Box sx={{ display: 'flex', gap: 2, marginBottom: 3}}>
        <Input onChange={searchDebounce.handleChange} value={searchDebounce.search} placeholder='Search for a product' sx={{
          maxWidth: 400
        }} />
        <Button onClick={sortByPriceHandler} variant='outlined' color='secondary' > Sort by price {priceSort ? <ArrowDropUpIcon /> : <ArrowDropDownIcon />}</Button>
      </Box>
      <Grid container spacing={2} sx={{
        marginTop: 8,
        marginBottom: 4
      }}>
        {itemsToShow.map(item => 
          <ProductOnGrid key={item.id} product={item} />)
        }
      </Grid>
      <Pagination page={page} count={pageCount} onChange={(e, value) => handleChange(e, value)} sx={{
        alignSelf: 'center'
      }} />
    </Container>
  )
}

export default ProductsPage