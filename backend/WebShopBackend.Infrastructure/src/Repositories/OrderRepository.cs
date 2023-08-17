using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(DatabaseContext context) : base(context)
    {
    }
    
    public override List<Order> GetAll(QueryOptions queryOptions)
    {
        var items = _dbSet
            .Include(e => e.OrderProducts)
            .Where(e => 
                e.User.Email.ToLower().Contains(
                    queryOptions.Filter.ToLower()
                )
            )
            .OrderBy(e => e.CreatedAt);
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
    
    
    public override Order GetOne(Guid id)
    {
        var entity = _dbSet
            .Include(e => e.User)
            .Include(e => e.OrderProducts)
            .Include(e => e.Address)
            .FirstOrDefault(e => e.Id == id);
        if (entity is null)
        {
            throw new KeyNotFoundException("Wrong id!");
        }

        return entity;
    }
}