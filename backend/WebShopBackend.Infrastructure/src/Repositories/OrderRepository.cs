using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>
{
    public OrderRepository(DatabaseContext context) : base(context)
    {
    }
}