namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IBaseEntity
{
    Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; } 
    public DateTimeOffset? UpdatedAt { get; set; }
}