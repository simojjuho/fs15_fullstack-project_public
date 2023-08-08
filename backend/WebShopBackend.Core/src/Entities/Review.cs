using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class Review : IReview
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid ProductId { get; set; }
    public IProduct Product { get; set; }
    public Guid UserId { get; set; }
    public IUser User { get; set; }
    public string Content { get; set; }
}