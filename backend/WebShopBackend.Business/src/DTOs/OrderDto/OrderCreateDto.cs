using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderCreateDto
{
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public List<OrderProductDto> OrderProducts { get; set; }
}