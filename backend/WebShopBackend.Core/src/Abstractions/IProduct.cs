namespace WebShopBackend.Core.Abstractions;

public interface IProduct : IBaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Desctiption { get; set; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; set; }
}