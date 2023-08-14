using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<User> _users;
    
    public UserRepository(DatabaseContext context)
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

    public List<User> GetAll(QueryOptions queryOptions)
    {
        var users = _users
            .Where(e => (e.FirstName + " " + e.LastName).Contains(queryOptions.Filter))
            .OrderBy(e => e.LastName);

        if (queryOptions.OrderDesc)
        {
            return users
                .OrderDescending()
                .Skip((queryOptions.Page - 1) * queryOptions.Page)
                .Take(queryOptions.PerPage)
                .ToList();
        }
        return users
            .Skip((queryOptions.Page - 1) * queryOptions.Page)
            .Take(queryOptions.PerPage)
            .ToList();
    }

    public User GetOne(Guid id)
    {
        var user = _users.Find(id);
        if (user is null)
        {
            throw new KeyNotFoundException();
        }

        return user;
    }

    public User Create(User item)
    {
        var entry = _users.Add(item);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    public User Update(User itemForUpdate)
    {
        var entry = _users.Update(itemForUpdate);
        _dbContext.SaveChanges();
        return entry.Entity;
    }

    public bool Remove(User item)
    {
        _users.Remove(item);
        _dbContext.SaveChanges();
        return true;
    }
}