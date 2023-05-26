using LightNovelLibrary.BuildingBlocks.Domain.Pagination;
using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelPage;

public class GetLightNovelPageHandler : IRequestHandler<GetLightNovelPageQuery, PaginationResult<LightNovelListDto>>
{
    private readonly ILightNovelRepository _repository;

    public GetLightNovelPageHandler(ILightNovelRepository repository)
    {
        _repository = repository;
    }

    public Task<PaginationResult<LightNovelListDto>> Handle(GetLightNovelPageQuery request, CancellationToken cancellationToken)
    {
        //考虑用dapper来查询，方便定制，也不受模块限制
        return Task.FromResult(_repository.GetLightNovelPage(request.Query).Convert(e =>
        {
            return new LightNovelListDto
            {
                LightNovelId = e.LightNovelId,
                Name = e.Name,
                Status = e.Status,
                UpdateTime = e.UpdateTime,
                AuthorId = e.AuthorId
            };
        }));
    }
}

