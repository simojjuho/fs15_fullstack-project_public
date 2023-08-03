using System.ComponentModel.DataAnnotations;
using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Entities;

public class User: IUser
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarId { get; set; }
    public UserRoles UserRole { get; set; }
}