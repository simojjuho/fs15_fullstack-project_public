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
    public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    public override UserGetDto Create(UserCreateDto item)
    {
        var newUser = _mapper.Map<User>(item);
        PasswordService.HashPassword(item.Password, out var hashedPassword, out var salt);
        newUser.PasswordHash = hashedPassword;
        newUser.Salt = salt;
        newUser.UserRole = UserRole.Customer;
        return _mapper.Map<UserGetDto>(_repository.Create(newUser));
    }

    public bool ChangeAdminStatus(Guid id)
    {
        var user = _repository.GetOne(id);
        user.UserRole = UserRole.Admin;
        _repository.Update(user);
        return true;
    }
}