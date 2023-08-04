using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Business.DTOs;

public class ReviewDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; }
    public Guid ProductId { get; set; }
    public IProduct Product { get; set; }
    public Guid UserId { get; set; }
    public IUser User { get; set; }
    public string Content { get; set; }
}