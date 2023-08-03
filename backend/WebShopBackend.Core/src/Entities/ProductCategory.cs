using System.ComponentModel.DataAnnotations;
using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class ProductCategory : IProductCategory
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}