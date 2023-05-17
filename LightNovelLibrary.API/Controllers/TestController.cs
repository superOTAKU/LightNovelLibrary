using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace LightNovelLibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TestController : ControllerBase
{
    [HttpGet]
    public IList<string> getList()
    {
        return new List<string> { "Jack", "Marry", "David" };
    }
}
