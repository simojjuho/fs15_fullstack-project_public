using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IOrder : IBaseEntity
{
    Guid UserId { get; set; }
    User User { get; set; }
    Guid AddressId { get; set; }
    Address Address { get; set; }
    OrderStatus OrderStatus { get; set; }
}