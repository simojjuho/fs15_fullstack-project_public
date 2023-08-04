using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public User GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public User Create(User item)
    {
        throw new NotImplementedException();
    }

    public User Update(User itemForUpdate, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll(int page, int perPage, string filter, string filterBy, string orderBy, bool orderDesc)
    {
        throw new NotImplementedException();
    }

    public bool ChangePassword(string newPassword, Guid userId)
    {
        throw new NotImplementedException();
    }
}