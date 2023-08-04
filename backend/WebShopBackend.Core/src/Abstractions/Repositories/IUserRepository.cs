using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    List<User> GetAll(int page, int perPage, string filter, string filterBy, string orderBy, bool orderDesc);
    bool ChangePassword(string newPassword, Guid userId);
}