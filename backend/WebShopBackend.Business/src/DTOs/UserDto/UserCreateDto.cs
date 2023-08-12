using AutoMapper.Configuration.Annotations;

namespace WebShopBackend.Business.DTOs.UserDto;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Ignore]
    public string AvatarUrl { get; set; }
    public string Password { get; set; }
}