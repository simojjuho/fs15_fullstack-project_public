namespace WebShopBackend.Business.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Desctiption { get; set; }
}