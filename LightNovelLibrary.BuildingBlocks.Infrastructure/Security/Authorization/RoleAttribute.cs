using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security.Authorization;

/// <summary>
/// 权限校验注解，判断当前用户是否有权限
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;

    public RoleAttribute(string role)
    {
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
        //检查当前拥有的角色是否符合要求
        var roles = claims.Where(c => c.Type == ClaimTypes.Role)
            .Select(c => IRole.RoleDictionary[c.Value]);

        if (!roles.Any(r => r.Includes(IRole.RoleDictionary[_role]))) 
        {
            context.Result = new ForbidResult();
            return;
        }
    }
}

