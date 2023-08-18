using Microsoft.EntityFrameworkCore;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;
using WebShopBackend.Core.HelperClasses;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class OrderProductRepository : IOrderProductRepository
{
    protected readonly DatabaseContext _dbContext;
    protected readonly DbSet<OrderProduct> _orderProducts;

    public OrderProductRepository(DatabaseContext context)
    {
        _dbContext = context;
        _orderProducts = context.Set<OrderProduct>();
    }
    public List<OrderProduct> GetAll(OrderProductQuery query)
    {
        switch (query.FilterBy)
        {
            case OrderProductsFilterBy.Order:
                return _orderProducts
                    .Where(
                        e => e.OrderId == query.Id
                    )
                    .OrderBy(e => e.Product.Title)
                    .OrderDescending()
                    .ToList();
            case OrderProductsFilterBy.Product:
                return _orderProducts
                    .Where(
                        e => e.OrderId == query.Id
                    )
                    .OrderBy(e => e.Product.Title)
                    .OrderDescending()
                    .ToList();
            default:
                throw CustomException.InvalidDataException();
        }
    }

    public OrderProduct GetOne(Guid productId, Guid orderId)
    {
        var entity = _orderProducts.FirstOrDefault(e => e.OrderId == orderId && e.ProductId == productId);
        if (entity is null)
        {
            throw CustomException.InvalidDataException();
        }

        return entity;
    }

    public OrderProduct Create(OrderProduct item)
    {
        Console.WriteLine("Before add!");
        var addedEntity = _orderProducts.Add(item);
        _dbContext.SaveChanges();
        return addedEntity.Entity;
    }

    public OrderProduct Update(OrderProduct itemForUpdate)
    {
        _orderProducts.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return itemForUpdate;
    }

    public bool Remove(OrderProduct item)
    {
        _orderProducts.Remove(item);
        _dbContext.SaveChanges();
        return true;    
    }
}