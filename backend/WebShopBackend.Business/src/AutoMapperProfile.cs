using AutoMapper;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserGetDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductCreateDto>();
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
    }
}