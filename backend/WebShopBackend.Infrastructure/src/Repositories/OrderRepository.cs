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
            .AsEnumerable()
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
}