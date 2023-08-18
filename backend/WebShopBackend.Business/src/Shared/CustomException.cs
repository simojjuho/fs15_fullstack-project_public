namespace WebShopBackend.Business.Shared;

public class CustomException : Exception
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }

    public CustomException(int status = 500, string message = "Unknown error")
    {
        StatusCode = status;
        ErrorMessage = message;
    }

    public static CustomException NotFoundException(string message = "Resource not found")
    {
        return new CustomException(404, message);
    }

    public static CustomException InvalidDataException(string message = "Invalid data")
    {
        return new CustomException(400);
    }

    public static CustomException UnauthorizedAccessException(string message = "Unauthorized Access!")
    {
        return new CustomException(403);
    }

    public static CustomException UnauthenticatedException(string message = "Access denies, login first!")
    {
        return new CustomException(401);
    }
}