using AutoMapper;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Business.Services;

public class UserService : BaseService<User, UserGetDto, UserCreateDto, UserUpdateDto>, IUserService
{
    protected UserService(IBaseRepository<User> repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    public override UserGetDto Create(UserCreateDto item)
    {
        var newUser = _mapper.Map<User>(item);
        newUser.UserRole = UserRoles.Customer;
        PasswordService.HashPassword(item.Password, out var hashedPassword, out var salt);
        newUser.PasswordHash = hashedPassword;
        newUser.Salt = salt;
        return _mapper.Map<UserGetDto>(_repository.Create(newUser));
    }
}