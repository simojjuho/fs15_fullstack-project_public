using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlDataSourceBuilder("Server=localhost; Host=localhost; Port=5432;Database=webshop_platform;Username=ecomm_admin;Password=admin123;");
        optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}