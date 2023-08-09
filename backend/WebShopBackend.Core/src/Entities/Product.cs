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
    public string Desctiption { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}