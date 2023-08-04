namespace WebShopBackend.Business.Abstractions;

public interface IBaseService<T, TDto>
{
    TDto GetOneById(Guid id);
    TDto Create(T item);
    TDto Update(T itemForUpdate);
    bool Remove(Guid id);
}