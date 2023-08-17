using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopBackend.Business.Abstractions;
using WebShopBackend.Business.DTOs.OrderDto;
using WebShopBackend.Core.Entities;
using WebShopBackend.Core.HelperClasses;

namespace WebShopBackend.Controllers.Controllers;

[ApiController]
public class OrderController : CrudController<Order, OrderGetDto, OrderCreateDto, OrderUpdateDto>
{
    public OrderController(IBaseService<OrderGetDto, OrderCreateDto, OrderUpdateDto> service) : base(service)
    {
    }

    [Authorize("AdminPrivilege")]
    [HttpGet]
    public override ActionResult<List<OrderGetDto>> GetAll(QueryOptions queryOptions)
    {
        return base.GetAll(queryOptions);
    }

    [Authorize("CustomersOnly")]
    [HttpPost]
    public override ActionResult<OrderGetDto> Create(OrderCreateDto itemDto)
    {
        return base.Create(itemDto);
    }

    [Authorize("AdminsOnly")]
    [HttpPatch]
    public override ActionResult<OrderGetDto> Update(Guid id, OrderUpdateDto itemDto)
    {
        return base.Update(id, itemDto);
    }

    [Authorize("AdminsOnly")]
    [HttpDelete("{id}")]
    public override ActionResult<bool> Delete([FromRoute]Guid id)
    {
        return base.Delete(id);
    }
}