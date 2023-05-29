﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security.Authorization;

/// <summary>
/// 权限校验注解
/// FIXME 这个注解的设计有点小问题，_principleType用来区分是Admin还是User，那么剩下的_role是全称还是局部名称呢？
/// 包括Admin和User之间的权限是否会重叠，这些我还没考虑好
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PrincipleRoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _principalType;
    private readonly string _role;

    public PrincipleRoleAttribute(string principalType, string role)
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
        var principalTypeClaim = claims.FirstOrDefault(c => c.Type == SecurityClaimTypes.PrincipleType);
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
        //检查当前拥有的角色是否符合要求
        var roles = claims.Where(c => c.Type == ClaimTypes.Role)
            .Select(c => IRole.GetRole(c.Value));

        if (!roles.Any(r => r.Includes(IRole.GetRole(IRole.GetFullName(_principalType, _role))))) 
        {
            context.Result = new ForbidResult();
            return;
        }
    }
}
