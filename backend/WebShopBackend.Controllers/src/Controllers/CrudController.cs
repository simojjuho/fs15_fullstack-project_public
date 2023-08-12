using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Core.Entities;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class CrudController<T, TGetDto, TCreateDto, TUpdateDto> : ControllerBase
{
    protected IBaseService<TGetDto, TCreateDto, TUpdateDto> _service { get; }
    public CrudController(IBaseService<TGetDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 400)]
    public virtual ActionResult<List<TGetDto>> GetAll([FromQuery] QueryOptions queryOptions)
    {
        return Ok(_service.GetAll(queryOptions));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 404)]
    public virtual ActionResult<TGetDto> GetOne([FromRoute] Guid id)
    {
        return Ok(_service.GetOne(id));
    }

    [HttpPost]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 403)]
    public virtual ActionResult<TGetDto> Create([FromBody] TCreateDto itemDto)
    {
        return Ok(_service.Create(itemDto));
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 404)]
    public virtual ActionResult<TGetDto> Update([FromRoute] Guid id, [FromBody] TUpdateDto itemDto)
    {
        return Ok(_service.Update(id, itemDto));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(statusCode: 200)]
    [ProducesResponseType(statusCode: 401)]
    [ProducesResponseType(statusCode: 404)]
    public virtual ActionResult<bool> Delete([FromRoute] Guid id)
    {
        if (_service.Remove(id))
        {
            return NoContent();
        }

        throw new ArgumentException($"Invalid entity id: {id.ToString()}");
    }
}