using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions;

public interface IOrder : IBaseEntity
{
    Guid UserId { get; set; }
    IUser User { get; set; }
    Guid AddressId { get; set; }
    IAddress Address { get; set; }
    OrderStatus OrderStatus { get; set; }
}