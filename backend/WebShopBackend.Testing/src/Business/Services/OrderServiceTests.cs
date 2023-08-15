using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Business.Services;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Testing.Business.Services;

public class OrderServiceTests
{
    private IBaseService<OrderGetDto, OrderCreateDto, OrderUpdateDto> _orderService;

}