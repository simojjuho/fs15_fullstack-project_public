using AutoMapper.Configuration.Annotations;

namespace WebShopBackend.Business.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Ignore]
    public string AvatarUrl { get; set; }
}