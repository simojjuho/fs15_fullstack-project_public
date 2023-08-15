using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderCreateDto
{
    public UserGetDto User { get; set; }
    public Address Address { get; set; }
    public List<OrderProductDto> OrderProducts { get; set; }
}