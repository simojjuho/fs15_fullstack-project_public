namespace WebShopBackend.Core.Abstractions;

public interface IProductCategory : IBaseEntity
{
    string Title { get; set; }
    string Description { get; set; }
}