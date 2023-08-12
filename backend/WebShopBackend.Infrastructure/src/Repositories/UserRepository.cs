using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<User> _users;
    
    protected UserRepository(DatabaseContext context)
    {
        _dbContext = context;
        _users = context.Set<User>();
    }

    public User GetOneByEmail(string email)
    {
        var user = _users.FirstOrDefault(e => e.Email == email);
        if (user is null)
        {
            throw new ArgumentException("Invalid credentials");
        }

        return user;
    }

    public bool UpdatePassword(string newPassword, User user)
    {
        throw new NotImplementedException();
    }

    public User UpdateAdminStatus(string email)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll(QueryOptions queryOptions)
    {
        throw new NotImplementedException();
    }

    public User GetOne(Guid id)
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

    public bool Remove(User item)
    {
        throw new NotImplementedException();
    }
}