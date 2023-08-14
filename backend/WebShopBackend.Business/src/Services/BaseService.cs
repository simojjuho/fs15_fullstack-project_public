using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Business.Services;

public class BaseService<T , TGetDto, TCreateDto, TUpdateDto> : IBaseService<TGetDto, TCreateDto, TUpdateDto> where T : IBaseEntity
{
    protected readonly IBaseRepository<T> _repository;
    protected readonly IMapper _mapper;

    protected BaseService(IBaseRepository<T> repository, IMapper mapper)
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
        return _mapper.Map<List<TGetDto>>(_repository.GetAll(queryOptions));
    }

    public virtual TGetDto Create(TCreateDto item)
    {
        var newItem = _mapper.Map<T>(item);
        return _mapper.Map<TGetDto>(_repository.Create(newItem));
    }

    public virtual TGetDto Update(Guid updateId, TUpdateDto itemForUpdate)
    {
        var itemUpdate = _mapper.Map<T>(itemForUpdate);
        itemUpdate.Id = updateId;
        var actualItem = _repository.GetOne(itemUpdate.Id);
        EnttiyIterator<T>.CheckNullValues(actualItem, itemUpdate);
        EnttiyIterator<T>.ReplaceProperyValues(actualItem, itemUpdate);
        return _mapper.Map<TGetDto>(_repository.Update(actualItem));
    }

    public bool Remove(Guid id)
    {
        var item = _repository.GetOne(id);
        return _repository.Remove(item);
    }
}