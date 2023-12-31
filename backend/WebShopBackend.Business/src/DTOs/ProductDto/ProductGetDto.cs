using WebShopBackend.Business.DTOs.ProductCategoryDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.DTOs.ProductDto;

public class ProductGetDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    public ProductCategoryGetDto ProductCategory { get; set; }
}