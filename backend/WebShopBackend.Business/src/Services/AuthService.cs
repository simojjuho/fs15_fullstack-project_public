using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository repository, IConfiguration configuration)
    {
        _userRepository = repository;
    }
    
    public string VerifyCredentials(UserCredentials credentials)
    {
        var user = _userRepository.GetOneByEmail(credentials.Email);
        var isAuthenticated = PasswordService.VerifyPassword(credentials.Password, user.PasswordHash, user.Salt);
        if (!isAuthenticated)
        {
            throw new AuthenticationException();
        }

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var claims = new List<Claim>{
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Email, user.Email),
            new (ClaimTypes.Role, user.UserRole.ToString())
        };
        var secretKey = new JsonWebKey("secret");
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Issuer = "webshop-backend",
            Expires = DateTime.Now.AddMinutes(3600),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = signingCredentials
            };
        
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
        return token.ToString();
    }
}