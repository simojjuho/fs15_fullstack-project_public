using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class Product : IProduct
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    [Precision(10, 2)]
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}