using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Security.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.UserControllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [Role(UserRoleNames.User)]
    [HttpGet]
    public string GetUserInfo()
    {
        return "userInfo";
    }
    
    [Role(AdminRoleNames.Admin)]
    [HttpGet("admin")]
    public string GetAdminInfo()
    {
        return "adminInfo";
    }

}
