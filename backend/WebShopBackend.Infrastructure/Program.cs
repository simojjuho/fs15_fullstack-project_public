using System.Security.Claims;
using System.Text;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using Swashbuckle.AspNetCore.Filters;
using WebShopBackend.Business;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Business.DTOs.ProductCategoryDto;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Business.Services;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.AuthorizationRequirements;
using WebShopBackend.Infrastructure.Database;
using WebShopBackend.Infrastructure.Middleware;
using WebShopBackend.Infrastructure.Repositories;

namespace WebShopBackend.Infrastructure;

public class Program
{
    
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        
        IConfigurationRoot configuration = configBuilder.Build();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy  =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        // Database:
        var dbDataSource = new NpgsqlDataSourceBuilder(configuration.GetConnectionString("ProdConnection")).Build();
        builder.Services.AddDbContext<DatabaseContext>(
            (options) =>
            {
                options.UseNpgsql(dbDataSource).UseSnakeCaseNamingConvention();
            });
        builder.Services.AddSingleton<IInterceptor>(_ => new TimeStampInterceptor());

        // Add services to the container.
        builder
            .Services.AddControllers();

        // Repositories:
        builder.Services.AddTransient<IBaseRepository<Product>, ProductRepository>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IBaseRepository<ProductCategory>, ProductCategoryRepository>();
        builder.Services.AddTransient<IBaseRepository<Order>, OrderRepository>();
        builder.Services.AddTransient<IOrderProductRepository, OrderProductRepository>();
        builder.Services.AddTransient<IBaseRepository<Address>, AddressRepository>();


        // Add services:
        builder.Services
            .AddTransient<IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto>, ProductService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IBaseService<ProductCategoryGetDto, ProductCategoryCreateDto, ProductCategoryUpdateDto>,
                ProductCategoryService>()
            .AddTransient<IBaseService<OrderGetDto, OrderCreateDto, OrderUpdateDto>, OrderService>()
            .AddTransient<IBaseService<AddressGetDto, AddressCreateDto, AddressUpdateDto>, AddressService>();

        builder.Services
            .AddScoped<ErrorHandler>();

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Bearer token authentication",
                    Name = "Authentication",
                    In = ParameterLocation.Header,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

        builder.Services.Configure<RouteOptions>(options => 
            options.LowercaseUrls = true
        );

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "webshop-backend",
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSecret"])),
                    ValidateIssuerSigningKey = true,
                    ValidAlgorithms = new []{SecurityAlgorithms.HmacSha256}
                };
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminsOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("whitelist", policy => policy.RequireClaim(ClaimTypes.Email, "juho@mail.com"));
            options.AddPolicy("CustomersOnly", policy => policy.RequireRole("Customer"));
            options.AddPolicy("IsOwnerOrderGetDto", policy => policy.Requirements.Add(new OwnerOnlyOrderGetDto()));
            options.AddPolicy("IsOwnerOrderGetDto", policy => policy.Requirements.Add(new OwnerOnlyOrderUpdateDto()));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseHttpsRedirection();

        app.UseMiddleware<ErrorHandler>();

        app.UseCors();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}