using LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;
using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LightNovelController : ControllerBase
{
    private readonly IMediator _mediator;

    public LightNovelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<LightNovelDetailDto> GetById(int id)
    {
        // TODO: 异常处理，参数校验...
        return await _mediator.Send(new GetLightNovelByIdQuery
        {
            LightNovelId = id
        });
    }

    [HttpPost]
    public async Task<int> Add([FromBody]AddLightNovelCommand command)
    {
        return await _mediator.Send(command);
    }

}
