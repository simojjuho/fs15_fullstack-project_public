using WebShopBackend.Core.Abstractions.Repositories;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    public Review GetOneById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Review Create(Review item)
    {
        throw new NotImplementedException();
    }

    public Review Update(Review itemForUpdate, Guid id)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Guid id)
    {
        throw new NotImplementedException();
    }
}