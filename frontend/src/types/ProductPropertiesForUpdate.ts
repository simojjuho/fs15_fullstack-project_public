interface ProductPropertiesForUpdate {
  id: string,
  data: {
    title: string
    price: number,
    description: string
    categoryId: string,
    inventory: number
  }
}

export default ProductPropertiesForUpdate

/*     public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    [Ignore]
    public Guid ProductCategoryId { get; set; } */