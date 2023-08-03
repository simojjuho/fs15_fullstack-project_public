namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IBaseRepository<T>
{
    T GetOneById(Guid id);
    T Create(T item);
    T Update(T itemForUpdate, Guid id);
    bool Remove(Guid id);
}