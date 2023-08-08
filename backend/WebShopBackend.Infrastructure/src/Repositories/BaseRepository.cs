using Microsoft.EntityFrameworkCore;

using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
namespace WebShopBackend.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }
    public List<T> GetAll(QueryOptions queryOptions)
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
            .ToList();
    }

    public T GetOne(T item)
    {
        return _dbSet.FirstOrDefault(item);
    }

    public T Create(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        return GetOne(item);
    }

    public T Update(T itemForUpdate, Guid id)
    {
        _dbSet.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return GetOne(itemForUpdate);
    }

    public bool Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        return true;    
    }
}