using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.UserControllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [PrincipleRole(PrincipalType.User, UserRoleNames.User)]
    [HttpGet]
    public string GetUserInfo()
    {
        return "userInfo";
    }

    [PrincipleRole(PrincipalType.Admin, AdminRoleNames.Admin)]
    [HttpGet("admin")]
    public string GetAdminInfo()
    {
        return "adminInfo";
    }

}
