using WebShopBackend.Core.Entities;

namespace WebShopBackend.Testing.HelperMethods;

public static class TestHelper
{
    public static Product CreateNewProduct(string? title, decimal? price, string? desctiption)
    {
        var newProduct = new Product();
        newProduct.Id = new Guid();
        if (title is not null)
        {
            newProduct.Title = title;    
        }

        if (price is not null)
        {
            newProduct.Price = (decimal)price;
        }

        if (desctiption is not null)
        {
            newProduct.Description = desctiption;
        }

        return newProduct;
    }
}



/*public Guid Id { get; set; }
public string Title { get; set; }
[Precision(10, 2)]
public decimal Price { get; set; }
public int Inventory { get; set; }
public string Desctiption { get; set; }
public DateTime CreatedAt { get; set; }
public DateTime? UpdatedAt { get; set; }*/