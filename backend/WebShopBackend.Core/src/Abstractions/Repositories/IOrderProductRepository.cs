using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IOrderProductRepository
{
    List<OrderProduct> GetAll(OrderProductQuery query);
    OrderProduct GetOne(Guid productId, Guid orderId);
    OrderProduct Create(OrderProduct item);
    OrderProduct Update(OrderProduct itemForUpdate);
    bool Remove(OrderProduct item);
}