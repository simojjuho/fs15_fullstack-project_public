namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IReview : IBaseEntity
{
    Guid ProductId{ get; set; }
    IProduct Product { get; set; }
    Guid UserId { get; set; }
    IUser User { get; set; }
    string Content { get; set; }
}