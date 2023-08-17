using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class Product : IProduct
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    public Guid ProductCategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}