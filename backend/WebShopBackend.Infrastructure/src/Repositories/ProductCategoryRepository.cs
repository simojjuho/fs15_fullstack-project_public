using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    public ProductCategory GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ProductCategory Create(ProductCategory item)
    {
        throw new NotImplementedException();
    }

    public ProductCategory Update(ProductCategory itemForUpdate, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<ProductCategory> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc)
    {
        throw new NotImplementedException();
    }
}