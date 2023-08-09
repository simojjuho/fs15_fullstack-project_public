using WebShopBackend.Core.Abstractions;

namespace WebShopBackend.Core.Entities;

public class OrderProduct : IOrderProduct
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}