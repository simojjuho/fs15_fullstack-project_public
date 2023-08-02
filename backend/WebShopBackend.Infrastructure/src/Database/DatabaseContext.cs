using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }


}