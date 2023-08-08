using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Core.Entities;

public class Address : IAddress
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get;  set;}
    public DateTime? UpdatedAt { get; set; }
    public Guid UserId { get; set; }
    public IUser User { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}