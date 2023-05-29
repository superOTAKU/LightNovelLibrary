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
        HttpContext.User.Identities.ToList().ForEach(Console.WriteLine);
        HttpContext.User.Claims.ToList() .ForEach(Console.WriteLine);
        return "userInfo";
    }
    
    [Role(AdminRoleNames.Admin)]
    [HttpGet("admin")]
    public string GetAdminInfo()
    {
        return "adminInfo";
    }

}
