using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IUser : IBaseEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Avatar { get; set; }
    UserRole UserRole { get; set; }
    string PasswordHash { get; set; }
    byte[] Salt { get; set; }
}