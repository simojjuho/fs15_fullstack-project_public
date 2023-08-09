using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Core.Abstractions.CoreEntities;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
[Route("api/v1/[controller]s)")]
public class CrudController<T, TDto> : ControllerBase
{
    private IBaseService<TDto> _service { get; }
    public CrudController(IBaseService<TDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<TDto>> GetAll([FromQuery] QueryOptions queryOptions)
    {
        return Ok(_service.GetAll(queryOptions));
    }

    [HttpGet("{id}")]
    public ActionResult<TDto> GetOne([FromBody] TDto itemDto)
    {
        return Ok(_service.GetOne(itemDto));
    }

    [HttpPost]
    public ActionResult<TDto> Create([FromBody] TDto itemDto)
    {
        return Ok(_service.Create(itemDto));
    }
}