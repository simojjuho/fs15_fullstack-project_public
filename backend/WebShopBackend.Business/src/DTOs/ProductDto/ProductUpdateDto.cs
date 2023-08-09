namespace WebShopBackend.Business.DTOs;

public class ProductUpdateDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Desctiption { get; set; }
}