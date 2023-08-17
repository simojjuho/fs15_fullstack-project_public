using AutoMapper;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Business.DTOs.ProductCategoryDto;
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
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<ProductCategory, ProductCategoryGetDto>();
        CreateMap<ProductCategoryCreateDto, ProductCategory>();
        CreateMap<ProductCategoryUpdateDto, ProductCategory>();
        CreateMap<OrderProduct, OrderProductDto>();
        CreateMap<OrderProductDto, OrderProduct>();
        CreateMap<Order, OrderGetDto>();
        CreateMap<OrderCreateDto, Order>();
        CreateMap<OrderUpdateDto, Order>();
        CreateMap<Address, AddressGetDto>();
        CreateMap<AddressCreateDto, Address>();
        CreateMap<AddressUpdateDto, Address>();
    }
}