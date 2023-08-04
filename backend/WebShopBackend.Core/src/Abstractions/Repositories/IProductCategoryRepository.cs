using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    List<ProductCategory> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc);
}