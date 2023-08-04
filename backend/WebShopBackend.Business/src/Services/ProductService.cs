using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class ProductService : IProductService
{
    public ProductDto GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ProductDto Create(Product item)
    {
        throw new NotImplementedException();
    }

    public ProductDto Update(Product itemForUpdate)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<ProductDto> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc, ProductCategory productCategory)
    {
        throw new NotImplementedException();
    }
}