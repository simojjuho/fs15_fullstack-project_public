using WebShopBackend.Business.Shared;
using WebShopBackend.Core.Entities;
using WebShopBackend.Testing.HelperMethods;

namespace WebShopBackend.Testing.Business.Helpers;

public class EntityIteratorTests
{
    [Fact]
    public void CheckNullValues_ProductEntities_Successful()
    {
        Product oldProd = TestHelper.CreateNewProduct("shoe", 10.00M, "Is great!");
        Product newProd = TestHelper.CreateNewProduct("shirt", 0.05M, null);
        EnttiyIterator<Product>.CheckNullValues(oldProd, newProd);
        
        Assert.Equal(oldProd.Description, newProd.Description);
        Assert.Equal("shirt", newProd.Title);
        Assert.Equal(0.05M, newProd.Price);
    }
    
    [Fact]
    public void ReplaceProperyValues_ProductEntities_Successful()
    {
        Product oldProd = TestHelper.CreateNewProduct("shoe", 10.00M, "Is great!");
        Product newProd = TestHelper.CreateNewProduct("shirt", 0.05M, null);
        EnttiyIterator<Product>.ReplaceProperyValues(oldProd, newProd);
        
        Assert.Equal(oldProd.Description, newProd.Description);
        Assert.Equal("shirt", oldProd.Title);
        Assert.Equal(0.05M, oldProd.Price);
    }
}