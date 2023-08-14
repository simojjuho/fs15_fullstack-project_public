using AutoMapper;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.DTOs.ProductCategoryDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductCategoryService : BaseService<ProductCategory ,ProductCategoryGetDto, ProductCategoryCreateDto, ProductCategoryUpdateDto>
{
    public ProductCategoryService(IBaseRepository<ProductCategory> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}