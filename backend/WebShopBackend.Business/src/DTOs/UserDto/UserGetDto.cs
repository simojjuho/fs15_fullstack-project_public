using AutoMapper.Configuration.Annotations;

namespace WebShopBackend.Business.DTOs.UserDto;

public class UserGetDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Ignore]
    public string Avatar { get; set; }
}