using AutoMapper;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
    }
}