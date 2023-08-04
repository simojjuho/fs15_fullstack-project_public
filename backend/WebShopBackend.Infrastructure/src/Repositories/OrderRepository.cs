using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    public Order GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Order Create(Order item)
    {
        throw new NotImplementedException();
    }

    public Order Update(Order itemForUpdate, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public Order GetAll(int page, int perPage, string orderBy, bool orderDesc)
    {
        throw new NotImplementedException();
    }
}