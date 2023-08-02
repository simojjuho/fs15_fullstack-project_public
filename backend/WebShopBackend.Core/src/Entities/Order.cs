using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Entities;

public class Order : IOrder
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public OrderStatus OrderStatus { get; set; }
}