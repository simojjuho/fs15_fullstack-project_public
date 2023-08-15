using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

public class OrderController : CrudController<Order, OrderGetDto, OrderCreateDto, OrderUpdateDto>
{
    public OrderController(IBaseService<OrderGetDto, OrderCreateDto, OrderUpdateDto> service) : base(service)
    {
    }
    
    
}