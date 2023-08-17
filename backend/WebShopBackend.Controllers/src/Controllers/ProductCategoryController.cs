using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs;
using WebShopBackend.Business.DTOs.ProductCategoryDto;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

public class ProductCategoryController : CrudController<ProductCategory, ProductCategoryGetDto, ProductCategoryCreateDto, ProductCategoryUpdateDto>
{
    public ProductCategoryController(IBaseService<ProductCategoryGetDto, ProductCategoryCreateDto, ProductCategoryUpdateDto> service) : base(service)
    {
    }
    
    [Authorize(Policy = "AdminsOnly")]
    [HttpPost]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 403)]
    public override ActionResult<ProductCategoryGetDto> Create([FromBody] ProductCategoryCreateDto itemDto)
    {
        return Ok(_service.Create(itemDto));
    }

    [Authorize(Policy = "AdminsOnly")]
    [HttpPatch("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 404)]
    public override ActionResult<ProductCategoryGetDto> Update([FromRoute] Guid id, [FromBody] ProductCategoryUpdateDto itemDto)
    {
        return Ok(_service.Update(id, itemDto));
    }

    [Authorize(Policy = "AdminsOnly")]
    [HttpDelete("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 404)]
    public override ActionResult<bool> Delete([FromRoute] Guid id)
    {
        if (_service.Remove(id))
        {
            return NoContent();
        }

        throw new ArgumentException($"Invalid entity id: {id.ToString()}");
    }
}