namespace WebShopBackend.Business.DTOs.AddressDto;

public class AddressGetDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StreetAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
}