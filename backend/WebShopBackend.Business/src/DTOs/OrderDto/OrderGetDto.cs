using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderGetDto
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public User User { get; set; }
    public Address Address { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public List<OrderProductDto> Products { get; set; }
}