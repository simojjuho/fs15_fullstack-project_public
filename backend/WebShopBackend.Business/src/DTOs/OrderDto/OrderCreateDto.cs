using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderCreateDto
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get;  set; }
    public UserGetDto User { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
}