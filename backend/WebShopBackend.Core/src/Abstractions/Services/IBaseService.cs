namespace WebShopBackend.Core.Abstractions.Services;

public interface IBaseService<T, TDto>
{
    TDto GetOneById(Guid id);
    TDto Create(TDto item);
    TDto Update(TDto itemForUpdate);
    bool Remove(Guid id);
}