using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Order GetAll(int page, int perPage, string orderBy, bool orderDesc);
}