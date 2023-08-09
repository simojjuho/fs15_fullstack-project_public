using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s)")]
public class CrudController<T, TGetDto, TCreateDto, TUpdateDto> : ControllerBase
{
    private IBaseService<TGetDto, TCreateDto, TUpdateDto> _service { get; }
    public CrudController(IBaseService<TGetDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<TGetDto>> GetAll([FromQuery] QueryOptions queryOptions)
    {
        return Ok(_service.GetAll(queryOptions));
    }

    [HttpGet("{id}")]
    public ActionResult<TGetDto> GetOne([FromBody] Guid id)
    {
        return Ok(_service.GetOne(id));
    }

    [HttpPost]
    public ActionResult<TGetDto> Create([FromBody] TCreateDto itemDto)
    {
        return Ok(_service.Create(itemDto));
    }
}