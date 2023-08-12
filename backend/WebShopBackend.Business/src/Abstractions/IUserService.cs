using WebShopBackend.Business.DTOs.UserDto;

namespace WebShopBackend.Business.Abstractions;

public interface IUserService : IBaseService<UserGetDto, UserCreateDto, UserUpdateDto>
{
}