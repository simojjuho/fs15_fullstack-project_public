using WebShopBackend.Core.Abstractions;

namespace WebShopBackend.Core.Entities;

public class ProductCategory : IProductCategory
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}