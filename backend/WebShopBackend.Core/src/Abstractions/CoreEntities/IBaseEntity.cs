namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IBaseEntity
{
    Guid Id { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; set; }
}