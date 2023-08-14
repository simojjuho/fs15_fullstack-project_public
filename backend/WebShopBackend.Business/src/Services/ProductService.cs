using AutoMapper;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductService : BaseService<Product, ProductGetDto, ProductCreateDto, ProductUpdateDto>
{
    private IBaseRepository<ProductCategory> _categoryRepository;
    public ProductService(IBaseRepository<ProductCategory> productCategories, IBaseRepository<Product> repository, IMapper mapper) : base(repository, mapper)
    {
        _categoryRepository = productCategories;
    }

    public override ProductGetDto Update(Guid updateId, ProductUpdateDto itemForUpdate)
    {
        var itemUpdate = _mapper.Map<Product>(itemForUpdate);
        itemUpdate.ProductCategory = _categoryRepository.GetOne(itemUpdate.CategoryId);
        itemUpdate.Id = updateId;
        var actualItem = _repository.GetOne(itemUpdate.Id);
        EnttiyIterator<Product>.CheckNullValues(actualItem, itemUpdate);
        EnttiyIterator<Product>.ReplaceProperyValues(actualItem, itemUpdate);
        return _mapper.Map<ProductGetDto>(_repository.Update(actualItem));
    }
}