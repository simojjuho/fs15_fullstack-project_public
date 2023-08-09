using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions;

public interface IOrderProduct
{
    public Product Product { get; set; }
    public Order Order { get; set; }
    public int Amount { get; set; }
}