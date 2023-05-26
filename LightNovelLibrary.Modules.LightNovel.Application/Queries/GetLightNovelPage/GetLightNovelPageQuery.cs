using LightNovelLibrary.BuildingBlocks.Domain.Pagination;
using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelPage;

public class GetLightNovelPageQuery : IRequest<PaginationResult<LightNovelListDto>>
{
    public LightNovelPaginationQuery Query { get; set; } = null!;
}

