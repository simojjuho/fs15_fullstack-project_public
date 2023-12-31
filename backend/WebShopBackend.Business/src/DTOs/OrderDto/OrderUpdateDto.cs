using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderUpdateDto
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public List<OrderProductDto> OrderProductDtos { get; set; }
}