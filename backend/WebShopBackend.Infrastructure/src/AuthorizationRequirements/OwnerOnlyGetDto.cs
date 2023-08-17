using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebShopBackend.Business.DTOs.OrderDto;

namespace WebShopBackend.Infrastructure.AuthorizationRequirements;

public class OwnerOnlyOrderGetDto : IAuthorizationRequirement
{
    
}

public class OwnerOnlyHandlerOrderGetDto : AuthorizationHandler<OwnerOnlyOrderGetDto, OrderGetDto>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnerOnlyOrderGetDto requirement,
        OrderGetDto resource)
    {
        var authenticatedUser = context.User.FindFirst(e => e.Type == ClaimTypes.NameIdentifier)!.Value;
        if (resource.User.Id == new Guid(authenticatedUser))
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}