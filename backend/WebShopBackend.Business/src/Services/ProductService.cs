using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public ProductDto GetOneById(Guid id)
    {
        return _mapper.Map<ProductDto>(_repository.GetOneById(id));
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
        var withOldData = _repository.GetOneById(itemForUpdate.Id);
        var oldProps = withOldData.GetType().GetProperties();
        EnttiyIterator<Product>.CheckNullValues(withOldData, productUpdate);
        return _mapper.Map<ProductDto>(_repository.Update(productUpdate, itemForUpdate.Id));
    }

    public bool Remove(Guid id)
    {
        return _repository.Remove(id);
    }

    public List<ProductDto> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc, ProductCategory productCategory)
    {
        return _mapper.Map<List<ProductDto>>(_repository.GetAll(page, filter, filterBy, orderBy, orderDesc, productCategory));
    }
}