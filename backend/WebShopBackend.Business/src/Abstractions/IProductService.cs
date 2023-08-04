using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Abstractions;

public interface IProductService : IBaseService<Product, ProductDto>
{
    List<ProductDto> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc,
        ProductCategory productCategory);
}