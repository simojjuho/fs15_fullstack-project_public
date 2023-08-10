namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IProduct : IBaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }
}