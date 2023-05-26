﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class UserPrincipleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _principalType;
    private readonly string _role;

    public UserPrincipleAttribute(string principalType, string role)
    {
        _principalType = principalType;
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user.Identity?.IsAuthenticated ?? false)
        {
            context.Result = new ChallengeResult();
            return;
        }
        var claims = user.Claims;
        var principalTypeClaim = claims.First(c => c.Type == SecurityClaimTypes.PrincipleType);
        if (principalTypeClaim is null)
        {
            context.Result = new ChallengeResult();
            return;
        }
        if (principalTypeClaim.Value != _principalType)
        {
            context.Result = new ForbidResult();
            return;
        }
        //检查角色
    }
}
