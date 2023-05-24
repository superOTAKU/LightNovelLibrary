using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;
using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

    [HttpGet("error")]
    public void ErrorTest()
    {
        throw new Exception("test!!!");
    }

    [HttpGet("error2")]
    public void ErrorTest2()
    {
        throw new TestBusinessException("test business exception!!!");
    }

}

[HttpStatus(HttpStatusCode.NotFound)]
public class TestBusinessException : BusinessException {
    public TestBusinessException(string? message) : base(1, message)
    {
        
    }
}
