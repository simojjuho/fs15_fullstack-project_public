using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Npgsql;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.Enums;

namespace WebShopBackend.Infrastructure.Database;

public class DatabaseContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }

    public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlDataSourceBuilder(_configuration.GetConnectionString("DefaultConnection"));
        builder.MapEnum<UserRole>();
        builder.MapEnum<OrderStatus>();
        optionsBuilder.AddInterceptors(new TimeStampInterceptor());
        optionsBuilder.UseNpgsql(builder.Build()).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .ToTable(t => t.HasCheckConstraint("products_inventory_unsigned", "Inventory >= 0 AND Inventory < 65536"));
        modelBuilder.Entity<Product>()
            .ToTable(t => t.HasCheckConstraint("products_price_unsigned", "Price >= 0"));
        modelBuilder.HasPostgresEnum<UserRole>();
        modelBuilder.HasPostgresEnum<OrderStatus>();
        modelBuilder.Entity<User>()
            .Property(e => e.Avatar)
            .HasDefaultValue("https://gravatar.com/avatar/64a18a4cd914f298e737bde27cb24c29?s=400&d=mp&r=x");
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                if (property.ClrType == typeof(Guid) && property.Name == "Id")
                {
                    property.SetValueGeneratorFactory((_, __) => new SequentialGuidValueGenerator());
                }
            }
        }

        modelBuilder.Entity<User>()
            .HasAlternateKey(e => e.Email)
            .HasName("AlternateKeu_Email");
    }
}