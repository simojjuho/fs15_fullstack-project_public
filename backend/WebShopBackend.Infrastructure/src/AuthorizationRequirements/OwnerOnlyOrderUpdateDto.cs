using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebShopBackend.Business.DTOs.OrderDto;

namespace WebShopBackend.Infrastructure.AuthorizationRequirements;

public class OwnerOnlyOrderUpdateDto : IAuthorizationRequirement
{
    
}

public class OwnerOnlyHandlerOrderUpdateDto : AuthorizationHandler<OwnerOnlyOrderUpdateDto, OrderUpdateDto>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerOnlyOrderUpdateDto requirement,
        OrderUpdateDto resource)
    {
        var authenticatedUser = context.User.FindFirst(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (resource.Id == new Guid(authenticatedUser))
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}