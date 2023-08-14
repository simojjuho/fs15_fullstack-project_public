using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class ProductCategoryRepository : BaseRepository<ProductCategory>
{
    public ProductCategoryRepository(DatabaseContext context) : base(context)
    {
    }
}