using AutoMapper;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductService : BaseService<Product, ProductGetDto, ProductCreateDto, ProductUpdateDto>
{
    public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}