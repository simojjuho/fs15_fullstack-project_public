using WebShopBackend.Core.Abstractions;

namespace WebShopBackend.Core.Entities;

public class Product : IProduct
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Desctiption { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; set; }
}