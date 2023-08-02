using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions;

public interface IOrder : IBaseEntity
{
    Guid UserId { get; set; }
    Guid AddressId { get; set; }
    OrderStatus OrderStatus { get; set; }
}