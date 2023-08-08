using Microsoft.EntityFrameworkCore;
using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private DbContext _dbContext;
    private 
    public Product GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Product Create(Product item)
    {
        throw new NotImplementedException();
    }

    public Product Update(Product itemForUpdate, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc, ProductCategory productCategory)
    {
        throw new NotImplementedException();
    }
}