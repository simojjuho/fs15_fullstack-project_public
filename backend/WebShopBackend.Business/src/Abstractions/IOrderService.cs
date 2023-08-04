using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Abstractions;

public interface IOrderService : IBaseService<Order, OrderDto>
{
    OrderDto GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc);
}