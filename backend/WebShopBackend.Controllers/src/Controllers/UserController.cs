using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
public class UserController : CrudController<User, UserGetDto, UserCreateDto, UserUpdateDto>
{
    public UserController(IUserService service) : base(service)
    {
    }

    [Authorize]
    [HttpGet]
    public override ActionResult<List<UserGetDto>> GetAll(QueryOptions queryOptions)
    {
        return base.GetAll(queryOptions);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 404)]
    public override ActionResult<UserGetDto> GetOne([FromRoute] Guid id)
    {
        return Ok(_service.GetOne(id));
    }

    [Authorize]
    [HttpGet("profile")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public ActionResult<UserGetDto> GetProfile()
    {
        var id = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        return Ok(_service.GetOne(new Guid(id)));
    }

    [Authorize]
    public override ActionResult<UserGetDto> Update(Guid id, UserUpdateDto itemDto)
    {
        var idFromToken = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (new Guid(idFromToken) != id)
        {
            return Unauthorized("Unauthorized user update!");
        }
        return Ok(_service.Update(id, itemDto));
    }

    [Authorize]
    public override ActionResult<bool> Delete(Guid id)
    {
        var idFromToken = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (new Guid(idFromToken) != id)
        {
            return Unauthorized("Unauthorized user deletion!");
        }

        return Ok(true);
    }
}