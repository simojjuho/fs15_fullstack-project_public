namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IAddress : IBaseEntity
{
    Guid UserId { get; set; }
    IUser User { get; set; }
    string StreetAddress { get; set; }
    string PostalCode { get; set; }
    string City { get; set; } 
}