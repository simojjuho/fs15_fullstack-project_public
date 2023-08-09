using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IAddress : IBaseEntity
{
    Guid UserId { get; set; }
    User User { get; set; }
    string StreetAddress { get; set; }
    string PostalCode { get; set; }
    string City { get; set; } 
}