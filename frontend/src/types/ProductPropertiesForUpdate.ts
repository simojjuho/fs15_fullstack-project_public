interface ProductPropertiesForUpdate {
  id: number,
  data: {
    title?: string
    price?: number,
    description?: string
    category?: number
  }
  images?: {file: File}[]
}

export default ProductPropertiesForUpdate