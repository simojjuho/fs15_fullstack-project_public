using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>
{
    
    public ProductRepository(DatabaseContext context) : base(context)
    {
    }

    public override List<Product> GetAll(QueryOptions queryOptions)
    {
        var items = _dbSet
            .Where(e => e.Title.ToLower().Contains(queryOptions.Filter.ToLower()))
            .OrderBy(e => e.Title)
            .Include(product => product.ProductCategory);
        if (queryOptions.OrderDesc)
        {
            return items.OrderDescending()
                .Skip((queryOptions.Page - 1) * queryOptions.PerPage)
                .Take(queryOptions.PerPage)
                .ToList();
        }
        return items.Skip((queryOptions.Page - 1) * queryOptions.PerPage)
            .Take(queryOptions.PerPage)
            .ToList();    
    }
}