using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    List<Product> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc,
        ProductCategory productCategory);
}