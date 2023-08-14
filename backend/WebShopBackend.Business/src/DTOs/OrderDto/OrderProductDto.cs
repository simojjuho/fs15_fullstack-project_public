using WebShopBackend.Business.DTOs.ProductDto;

namespace WebShopBackend.Business.DTOs.OrderDto;

public class OrderProductDto
{
    public Guid ProductId { get; set; }
    public ProductGetDto Product { get; set; }
    public int Amount { get; set; }
}