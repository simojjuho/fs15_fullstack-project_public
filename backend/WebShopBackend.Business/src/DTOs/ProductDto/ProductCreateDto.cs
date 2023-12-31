using AutoMapper.Configuration.Annotations;

namespace WebShopBackend.Business.DTOs.ProductDto;

public class ProductCreateDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    [Ignore]
    public Guid ProductCategoryId { get; set; }
}