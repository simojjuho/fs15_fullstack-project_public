using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;

namespace WebShopBackend.Business.Services;

public class BaseService<T, TGetDto, TCreateDto, TUpdateDto> : IBaseService<TGetDto, TCreateDto, TUpdateDto> where T : IBaseEntity
{
    private readonly IBaseRepository<T> _repository;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public TGetDto GetOne(Guid id)
    {
        return _mapper.Map<TGetDto>(_repository.GetOne(id));
    }

    public List<TGetDto> GetAll(QueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public TGetDto Create(TCreateDto item)
    {
        var newItem = _mapper.Map<T>(item);
        newItem.CreatedAt = DateTime.Now;
        var madeProduct = _repository.Create(newItem);
        return _mapper.Map<TGetDto>(madeProduct);
    }

    public TGetDto Update(TUpdateDto itemForUpdate)
    {
        var itemUpdate = _mapper.Map<T>(itemForUpdate);
        var updateProps = itemUpdate.GetType().GetProperties();
        var withOldData = _repository.GetOne(itemUpdate.Id);
        var oldProps = withOldData.GetType().GetProperties();
        EnttiyIterator<T>.CheckNullValues(withOldData, itemUpdate);
        var id = itemUpdate.GetType().GetProperty("Id")!.GetValue(itemUpdate);
        if (id is not null && id.GetType().IsInstanceOfType(new Guid()))
        {
            return _mapper.Map<TGetDto>(_repository.Update(itemUpdate, (Guid)id));    
        }

        throw new NullReferenceException("Could not find an instance with the id.");
    }

    public bool Remove(Guid id)
    {
        var item = GetOne(id);
        return _repository.Remove(_mapper.Map<T>(item));
    }
}