using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

public class UserController : CrudController<User, UserGetDto, UserCreateDto, UserUpdateDto>
{
    public UserController(IBaseService<UserGetDto, UserCreateDto, UserUpdateDto> service) : base(service)
    {
    }

    [Authorize]
    public override ActionResult<List<UserGetDto>> GetAll(QueryOptions queryOptions)
    {
        return base.GetAll(queryOptions);
    }
}