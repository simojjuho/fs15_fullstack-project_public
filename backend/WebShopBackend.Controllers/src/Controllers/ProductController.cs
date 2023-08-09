using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

public class ProductController : CrudController<Product, ProductGetDto, ProductCreateDto, ProductUpdateDto>
{
    public ProductController(IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto> service) : base(service)
    {
    }
}