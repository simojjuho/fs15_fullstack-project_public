using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<Product> _dbSet;
    
    public ProductRepository(DatabaseContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<Product>();
    }

    public List<Product> GetAll(QueryOptions queryOptions)
    {
        var items = _dbSet
            .Where(e => e.GetType().GetProperty(queryOptions.FilterBy)!.GetValue(e)!.ToString() == queryOptions.Filter)
            .OrderBy(e => e.GetType().GetProperty(queryOptions.OrderBy));
        if (queryOptions.OrderDesc)
        {
            return items.OrderDescending()
                .Skip(queryOptions.Page * queryOptions.PerPage)
                .Take(queryOptions.PerPage)
                .ToList();
        }
        return items.Skip(queryOptions.Page * queryOptions.PerPage)
            .Take(queryOptions.PerPage)
            .ToList();    }

    public Product GetOne(Guid id)
    {
        var entity = _dbSet.Find(id);
        if (entity is null)
        {
            throw new KeyNotFoundException("Wrong id!");
        }

        return entity;    }

    public Product Create(Product item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        return GetOne((Guid)item.GetType().GetProperty("Id").GetValue(item));
    }

    public Product Update(Product itemForUpdate, Guid id)
    {
        _dbSet.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return GetOne(id);
    }

    public bool Remove(Product item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        return true;        }
}