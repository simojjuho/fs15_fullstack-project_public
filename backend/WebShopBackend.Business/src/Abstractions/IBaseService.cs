using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Business.Abstractions;

public interface IBaseService<TGetDto, TCreateDto, TUpdateDto>
{
    List<TGetDto> GetAll(QueryOptions queryOptions);
    TGetDto GetOne(Guid id);
    TGetDto Create(TCreateDto item);
    TGetDto Update(Guid id, TUpdateDto itemForUpdate);
    bool Remove(Guid id);
}