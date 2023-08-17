using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderGetDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public UserGetDto User { get; set; }
    public AddressGetDto Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public List<OrderProductDto> OrderProducts { get; set; }
}