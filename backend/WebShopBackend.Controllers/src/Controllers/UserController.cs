using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
public class UserController : CrudController<User, UserGetDto, UserCreateDto, UserUpdateDto>
{
    private readonly IUserService _userService;
    public UserController(IUserService service) : base(service)
    {
        _userService = service;
    }

    [Authorize(Policy = "AdminsOnly")]
    [HttpGet]
    public override ActionResult<List<UserGetDto>> GetAll(QueryOptions queryOptions)
    {
        return _userService.GetAll(queryOptions);
    }
    
    [Authorize(Policy = "AdminsOnly")]
    [HttpGet("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 404)]
    public override ActionResult<UserGetDto> GetOne([FromRoute] Guid id)
    {
        return Ok(_userService.GetOne(id));
    }

    [Authorize]
    [HttpGet("profile")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public ActionResult<UserGetDto> GetProfile()
    {
        var id = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        Console.WriteLine(id);
        return Ok(_userService.GetOne(new Guid(id)));
    }

    [Authorize(Policy = "AdminsOnly")]
    public override ActionResult<UserGetDto> Update(Guid id, UserUpdateDto itemDto)
    {
        var idFromToken = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (new Guid(idFromToken) != id)
        {
            return Unauthorized("Unauthorized user update!");
        }
        return Ok(_userService.Update(id, itemDto));
    }

    [Authorize]
    [HttpDelete]
    public override ActionResult<bool> Delete(Guid id)
    {
        var idFromToken = HttpContext.User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (new Guid(idFromToken) != id)
        {
            return Unauthorized("Unauthorized user deletion!");
        }

        return Ok(_userService.Remove(id));
    }

    [Authorize(Policy = "whitelist")]
    [HttpGet("{id}/adminswitch")]
    public ActionResult ChangeAdminStatus(Guid id)
    {
        return CreatedAtAction(nameof(ChangeAdminStatus), _userService.ChangeAdminStatus(id));
    }
    
}