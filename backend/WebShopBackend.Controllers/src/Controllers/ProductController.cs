using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.ProductDto;
using WebShopBackend.Business.Services;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
public class ProductController : CrudController<Product, ProductGetDto, ProductCreateDto, ProductUpdateDto>
{
    public ProductController(IBaseService<ProductGetDto, ProductCreateDto, ProductUpdateDto> service) : base(service)
    {
    }
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 400)]
    [ProducesResponseType(statusCode: 401)]
    public override ActionResult<ProductGetDto> Create([FromBody] ProductCreateDto itemDto)
    {
        return Ok(base._service.Create(itemDto));
    }
    
    [Authorize]
    [HttpPatch("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 400)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 404)]
    public override ActionResult<ProductGetDto> Update([FromRoute] Guid id, [FromBody] ProductUpdateDto itemDto)
    {
        return Ok(_service.Update(id, itemDto));
    }

    [Authorize]
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

        throw new ArgumentException($"Invalid product id: {id.ToString()}");
    }
}