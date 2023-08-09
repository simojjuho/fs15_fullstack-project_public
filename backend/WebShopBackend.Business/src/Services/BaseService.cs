using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;

namespace WebShopBackend.Business.Services;

public class BaseService<T, TDto> : IBaseService<TDto> where T : IBaseEntity
{
    private readonly IBaseRepository<T> _repository;
    private readonly IMapper _mapper;

    public BaseService(IBaseRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public TDto GetOne(TDto item)
    {
        return _mapper.Map<TDto>(_repository.GetOne(_mapper.Map<T>(item)));
    }

    public List<TDto> GetAll(QueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public TDto Create(TDto item)
    {
        var newItem = _mapper.Map<T>(item);
        newItem.CreatedAt = DateTime.Now;
        var madeProduct = _repository.Create(newItem);
        return _mapper.Map<TDto>(madeProduct);
    }

    public TDto Update(TDto itemForUpdate)
    {
        var itemUpdate = _mapper.Map<T>(itemForUpdate);
        var updateProps = itemUpdate.GetType().GetProperties();
        var withOldData = _repository.GetOne(itemUpdate);
        var oldProps = withOldData.GetType().GetProperties();
        EnttiyIterator<T>.CheckNullValues(withOldData, itemUpdate);
        var id = itemUpdate.GetType().GetProperty("Id")!.GetValue(itemUpdate);
        if (id is not null && id.GetType().IsInstanceOfType(new Guid()))
        {
            return _mapper.Map<TDto>(_repository.Update(itemUpdate, (Guid)id));    
        }

        throw new NullReferenceException("Could not find an instance with the id.");
    }

    public bool Remove(TDto item)
    {
        return _repository.Remove(_mapper.Map<T>(item));
    }
}