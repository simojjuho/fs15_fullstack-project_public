using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.AddressDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

[Authorize]
[ApiController]
public class AddressController : CrudController<Address, AddressGetDto, AddressCreateDto, AddressUpdateDto>
{
    public AddressController(IBaseService<AddressGetDto, AddressCreateDto, AddressUpdateDto> service) : base(service)
    {
    }
}