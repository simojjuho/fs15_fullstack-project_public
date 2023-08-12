using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using WebShopBackend.Business;
using WebShopBackend.Business.Services;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;
using WebShopBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database:
builder.Services.AddDbContext<DatabaseContext>();

// Add services to the container.
builder.Services.AddControllers();

// Repositories:
builder.Services.AddScoped<IBaseRepository<Product>, ProductRepository>();

// Add services:
builder.Services.AddScoped<IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto>, ProductService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Bearer token authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();