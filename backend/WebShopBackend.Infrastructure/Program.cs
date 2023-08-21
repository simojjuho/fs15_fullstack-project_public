using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebShopBackend.Business;
using WebShopBackend.Business.Services;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Business.DTOs.ProductCategoryDto;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.AuthorizationRequirements;
using WebShopBackend.Infrastructure.Database;
using WebShopBackend.Infrastructure.Middleware;
using WebShopBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
builder
    .Services.AddDbContext<DatabaseContext>(ServiceLifetime.Transient);

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
    .AddScoped<IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto>, ProductService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<IBaseService<ProductCategoryGetDto, ProductCategoryCreateDto, ProductCategoryUpdateDto>,
        ProductCategoryService>()
    .AddScoped<IBaseService<OrderGetDto, OrderCreateDto, OrderUpdateDto>, OrderService>()
    .AddScoped<IBaseService<AddressGetDto, AddressCreateDto, AddressUpdateDto>, AddressService>();

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("enGVsJ8JoaWKSOA7mpheC2EJFW3akghhWr69aNPhwrgabDpTt3GsW715vJ4lz0oieZW8jTFChXnCYPAMYSiligTGKSF2pV0uxBJx21UVJYqp9IcO1Qpr6FP1vXZ3IDWP")),
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandler>();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();