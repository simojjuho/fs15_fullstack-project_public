using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class Review : IReview
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
}