using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

public class ProductController : CrudController<Product, ProductDto>
{
    public ProductController(IProductService service) : base(service)
    {
    }
}