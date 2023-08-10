using WebShopBackend.Business;
using WebShopBackend.Business.Services;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Infrastructure.Database;
using WebShopBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database:
builder.Services.AddDbContext<DatabaseContext>();

// Add services to the container.
builder.Services.AddControllers();

// Repositories:
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services:
builder.Services.AddScoped<IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto>, ProductService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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