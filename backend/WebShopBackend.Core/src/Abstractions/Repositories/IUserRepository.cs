using WebShopBackend.Core.Entities;

namespace WebShopBackend.Core.Abstractions.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    User GetOneByEmail(string email);
}