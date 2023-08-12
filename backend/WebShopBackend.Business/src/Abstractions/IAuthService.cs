using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Abstractions;

public interface IAuthService
{
    public string VerifyCredentials(UserCredentials credentials);
    public string GenerateToken(User user);
}