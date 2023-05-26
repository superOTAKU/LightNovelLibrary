using LightNovelLibrary.BuildingBlocks.Domain.Pagination;
using LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;
using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;
using LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelPage;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API.PublicControllers;

[ApiController]
[Route("[controller]")]
public class PublicLightNovelController : ControllerBase
{
    private readonly IMediator _mediator;

    public PublicLightNovelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<LightNovelDetailDto> GetById(int id)
    {
        return await _mediator.Send(new GetLightNovelByIdQuery
        {
            LightNovelId = id
        });
    }

    [HttpPost("page")]
    public async Task<PaginationResult<LightNovelListDto>> GetPage([FromBody]LightNovelPaginationQuery query)
    {
        return await _mediator.Send(new GetLightNovelPageQuery
        {
            Query = query
        });
    }

    [HttpPost]
    public async Task<int> Add([FromBody]AddLightNovelCommand command)
    {
        return await _mediator.Send(command);
    }

}

