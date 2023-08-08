using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Business.Abstractions;

public interface IBaseService<TDto>
{
    List<TDto> GetAll(QueryOptions queryOptions);
    TDto GetOne(TDto item);
    TDto Create(TDto item);
    TDto Update(TDto itemForUpdate);
    bool Remove(TDto item);
}