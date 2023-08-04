using WebShopBackend.Core.Entities;
using WebShopBackend.Business.Helpers;
using WebShopBackend.Testing.HelperMethods;

namespace WebShopBackend.Testing.Business.Helpers;

public class EntityIteratorTests
{
    [Fact]
    public void ChckNullValues_ProductEntities_Successful()
    {
        Product oldProd = TestHelper.CreateNewProduct("shoe", 10.00M, "Is great!");
        Product newProd = TestHelper.CreateNewProduct("shirt", 0.05M, null);
        EnttiyIterator<Product>.CheckNullValues(oldProd, newProd);
        
        Assert.Equivalent(oldProd, newProd);
    }
}