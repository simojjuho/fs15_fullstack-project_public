using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;
using WebShopBackend.Core.HelperClasses;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class OrderProductRepository
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<OrderProduct> _dbSet;

    public OrderProductRepository(DatabaseContext context)
    {
        _dbContext = context;
        _dbSet = context.Set<OrderProduct>();
    }
    public List<OrderProduct> GetAll(OrderProductQuery query)
    {
        switch (query.flterBy)
        {
            case OrderProductsFilterBy.Order:
                return _dbSet
                    .Where(
                        e => e.OrderId == query.Id
                    )
                    .OrderBy(e => e.Product.Title)
                    .OrderDescending()
                    .ToList();
            case OrderProductsFilterBy.Product:
                return _dbSet
                    .Where(
                        e => e.OrderId == query.Id
                    )
                    .OrderBy(e => e.Product.Title)
                    .OrderDescending()
                    .ToList();
            default:
                throw new ArgumentException();
        }
    }

    public OrderProduct GetOne(Guid productId, Guid orderId)
    {
        var entity = _dbSet.FirstOrDefault(e => e.OrderId == orderId && e.ProductId == productId);
        if (entity is null)
        {
            throw new KeyNotFoundException("Wrong id!");
        }

        return entity;
    }

    public OrderProduct Create(OrderProduct item)
    {
        _dbSet.Add(item);
        _dbContext.SaveChanges();
        return item;
    }

    public OrderProduct Update(OrderProduct itemForUpdate)
    {
        _dbSet.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return itemForUpdate;
    }

    public bool Remove(OrderProduct item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        return true;    
    }
}