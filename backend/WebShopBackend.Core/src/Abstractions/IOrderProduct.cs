using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions;

public interface IOrderProduct
{
    Guid ProductId { get; set; }
    Product Product { get; set; }
    Guid OrderId { get; set; }
    Order Order { get; set; }
}