using WebShopBackend.Core.Entities;
using WebShopBackend.Infrastructure.Database;

namespace WebShopBackend.Infrastructure.Repositories;

public class AddressRepository : BaseRepository<Address>
{
    public AddressRepository(DatabaseContext context) : base(context)
    {
    }
}