namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IProductCategory : IBaseEntity
{
    string Title { get; set; }
    string Description { get; set; }
}