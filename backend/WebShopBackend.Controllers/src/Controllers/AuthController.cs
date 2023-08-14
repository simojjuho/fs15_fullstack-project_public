using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost]
    public ActionResult<string> VerifyCredentials(UserCredentials userCredentials)
    {
        return Ok(_authService.VerifyCredentials(userCredentials));
    }
}