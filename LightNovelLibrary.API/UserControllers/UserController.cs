using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.UserControllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [Authorize]
    [HttpGet]
    public string GetUserInfo()
    {
        return "userInfo";
    }

}
