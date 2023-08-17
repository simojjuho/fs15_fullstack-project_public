namespace WebShopBackend.Business.DTOs.AddressDto;

public class AddressCreateDto
{
    public Guid? UserId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}