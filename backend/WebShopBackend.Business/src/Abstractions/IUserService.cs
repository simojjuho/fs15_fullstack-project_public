using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Abstractions;

public interface IUserService : IBaseService<User, UserDto>
{
    List<UserDto> GetAll(int page, int perPage, string filter, string filterBy, string orderBy, bool orderDesc);
    bool ChangePassword(string newPassword);
}