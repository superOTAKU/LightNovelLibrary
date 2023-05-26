using LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.AdminControllers;

[Route("[controller]")]
[ApiController]
public class AdminLightNovelController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminLightNovelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<int> Add([FromBody] AddLightNovelCommand command)
    {
        return await _mediator.Send(command);
    }
}
