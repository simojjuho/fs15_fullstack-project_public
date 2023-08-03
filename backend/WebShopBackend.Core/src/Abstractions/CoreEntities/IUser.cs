using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Abstractions.CoreEntities;

public interface IUser : IBaseEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string AvatarId { get; set; }
    UserRoles UserRole { get; set; }
    // TODO: User need passwordHash!
}