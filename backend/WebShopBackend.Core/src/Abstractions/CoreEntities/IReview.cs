using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IReview : IBaseEntity
{
    Guid ProductId{ get; set; }
    Product Product { get; set; }
    Guid UserId { get; set; }
    User User { get; set; }
    string Content { get; set; }
}