using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    List<T> GetAll(QueryOptions queryOptions);
    T GetOne(Guid id);
    T Create(T item);
    T Update(T itemForUpdate, Guid id);
    bool Remove(T item);
}