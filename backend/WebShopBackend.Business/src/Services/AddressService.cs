using AutoMapper;
using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class AddressService : BaseService<Address, AddressGetDto, AddressCreateDto, AddressUpdateDto>
{
    public AddressService(IBaseRepository<Address> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}