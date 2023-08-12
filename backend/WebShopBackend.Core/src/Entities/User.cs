using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;
using WebShopBackend.Core.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Core.Entities;

public class User: IUser
{
    [Key]
    public Guid Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Ignore]
    public string AvatarId { get; set; }
    public UserRoles UserRole { get; set; } = UserRoles.Customer;
    public string PasswordHash { get; set; }
    public byte[] Salt { get; set; }
}