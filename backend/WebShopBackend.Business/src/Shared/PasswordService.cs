using System.Text;
using HMACSHA256 = System.Security.Cryptography.HMACSHA256;

namespace WebShopBackend.Business.Shared;

public class PasswordService
{
    public static void HashPassword(string password, out string hashedPassword, out byte[] salt)
    {
        var hmac = new HMACSHA256();
        salt = hmac.Key;
        hashedPassword = Encoding.UTF8.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }

    public static bool VerifyPassword(string passwordFromLogin, string passwordHash, byte[] salt)
    {
        var hmac = new HMACSHA256(salt);
        var passwordOrig = Encoding.UTF8.GetString(hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordFromLogin)));
        return passwordHash == passwordOrig;
    }
}