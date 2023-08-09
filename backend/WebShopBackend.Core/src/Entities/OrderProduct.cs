using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions;

namespace WebShopBackend.Core.Entities;

[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class OrderProduct : IOrderProduct
{
    [ForeignKey(nameof(Product))]
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    [ForeignKey(nameof(Order))]
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public int Amount { get; set; }
}