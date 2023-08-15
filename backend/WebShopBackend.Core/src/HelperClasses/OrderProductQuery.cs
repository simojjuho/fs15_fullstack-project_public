using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.HelperClasses;

public class OrderProductQuery
{
    public OrderProductsFilterBy FilterBy { get; set; }
    public Guid Id { get; set; }
}