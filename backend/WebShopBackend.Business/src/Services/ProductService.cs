using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _repository;
    private readonly IMapper _mapper;

    public ProductService(IBaseRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public ProductDto GetOne(ProductDto item)
    {
        return _mapper.Map<ProductDto>(_repository.GetOne(_mapper.Map<Product>(item)));
    }

    public List<ProductDto> GetAll(QueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public ProductDto Create(ProductDto item)
    {
        var newProduct = _mapper.Map<Product>(item);
        newProduct.CreatedAt = DateTime.Now;
        var madeProduct = _repository.Create(newProduct);
        return _mapper.Map<ProductDto>(madeProduct);
    }

    public ProductDto Update(ProductDto itemForUpdate)
    {
        var productUpdate = _mapper.Map<Product>(itemForUpdate);
        var updateProps = productUpdate.GetType().GetProperties();
        var withOldData = _repository.GetOne(productUpdate);
        var oldProps = withOldData.GetType().GetProperties();
        EnttiyIterator<Product>.CheckNullValues(withOldData, productUpdate);
        return _mapper.Map<ProductDto>(_repository.Update(productUpdate, itemForUpdate.Id));
    }

    public bool Remove(ProductDto item)
    {
        return _repository.Remove(_mapper.Map<Product>(item));
    }
}