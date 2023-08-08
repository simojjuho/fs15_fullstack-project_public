using WebShopBackend.Business.DTOs;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Business.Abstractions;

public interface IProductCategoryService : IBaseService<ProductCategoryDto>
{
    List<ProductCategoryDto> GetAll(int page, string filter, string filterBy, string orderBy, bool orderDesc);
}