using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.UserDto;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Shared;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository repository)
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
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("enGVsJ8JoaWKSOA7mpheC2EJFW3akghhWr69aNPhwrgabDpTt3GsW715vJ4lz0oieZW8jTFChXnCYPAMYSiligTGKSF2pV0uxBJx21UVJYqp9IcO1Qpr6FP1vXZ3IDWP"));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor{
            Issuer = "webshop-backend",
            Expires = DateTime.Now.AddMinutes(3600),
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = signingCredentials
            };
        
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
        return jwtSecurityTokenHandler.WriteToken(token);
    }
}