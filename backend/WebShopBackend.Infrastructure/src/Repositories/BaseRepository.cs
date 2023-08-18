using Microsoft.EntityFrameworkCore;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.HelperClasses;
using WebShopBackend.Infrastructure.Database;
using WebShopBackend.Infrastructure.Middleware;

namespace WebShopBackend.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    protected BaseRepository(DatabaseContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<T>();
    }
    public virtual List<T> GetAll(QueryOptions queryOptions)
    {
        var items = _dbSet
            .AsEnumerable()
            .Where(e => 
                e.GetType().GetProperty(queryOptions.FilterBy)!.GetValue(e)!.ToString()!.ToLower().Contains(
                    queryOptions.Filter.ToLower()
                    )
            )
            .OrderBy(e => e.GetType().GetProperty(queryOptions.OrderBy));
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

    public virtual T GetOne(Guid id)
    {
        var entity = _dbSet.Find(id);
        if (entity is null)
        {
            throw CustomException.NotFoundException();
        }

        return entity;
    }

    public virtual T Create(T item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        return GetOne((Guid) item.Id);
    }

    public virtual T Update(T itemForUpdate)
    {
        _dbSet.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return itemForUpdate;
    }

    public virtual bool Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        return true;    
    }
}