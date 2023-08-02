using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions;

public interface IUser : IBaseEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string AvatarId { get; set; }
    UserRoles UserRole { get; set; }
}