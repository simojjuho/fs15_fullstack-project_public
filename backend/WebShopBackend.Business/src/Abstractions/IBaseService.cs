using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Business.Abstractions;

public interface IBaseService<TGetDto, TCreateDto, TUpdateDto>
{
    List<TGetDto> GetAll(QueryOptions queryOptions);
    TGetDto GetOne(Guid id);
    TGetDto Create(TCreateDto item);
    TGetDto Update(TUpdateDto itemForUpdate);
    bool Remove(Guid id);
}