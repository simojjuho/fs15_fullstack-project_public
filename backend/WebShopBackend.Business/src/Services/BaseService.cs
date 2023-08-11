using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class BaseService<T , TGetDto, TCreateDto, TUpdateDto> : IBaseService<TGetDto, TCreateDto, TUpdateDto> where T : IBaseEntity
{
    private readonly IBaseRepository<T> _repository;
    private readonly IMapper _mapper;

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

    public TGetDto Create(TCreateDto item)
    {
        var newItem = _mapper.Map<T>(item);
        newItem.CreatedAt = DateTime.Now;
        var madeProduct = _repository.Create(newItem);
        return _mapper.Map<TGetDto>(madeProduct);
    }

    public TGetDto Update(Guid updateId, TUpdateDto itemForUpdate)
    {
        var itemUpdate = _mapper.Map<T>(itemForUpdate);
        itemUpdate.Id = updateId;
        var withOldData = _repository.GetOne(itemUpdate.Id);
        EnttiyIterator<T>.CheckNullValues(withOldData, itemUpdate);
        return _mapper.Map<TGetDto>(_repository.Update(itemUpdate, updateId));
    }

    public bool Remove(Guid id)
    {
        var item = GetOne(id);
        return _repository.Remove(_mapper.Map<T>(item));
    }
}