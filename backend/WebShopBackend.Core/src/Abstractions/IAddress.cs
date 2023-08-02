namespace WebShopBackend.Core.Abstractions;

public interface IAddress : IBaseEntity
{
    Guid UserId { get; set; }
    IUser User { get; set; }
    string StreetAddress { get; set; }
    string PostalCode { get; set; }
    string City { get; set; } 
}