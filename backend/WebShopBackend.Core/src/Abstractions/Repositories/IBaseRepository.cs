using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    List<T> GetAll(QueryOptions queryOptions);
    T GetOne(Guid id);
    T Create(T item);
    T Update(T itemForUpdate);
    bool Remove(T item);
}