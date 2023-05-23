using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;

public class GetLightNovelByIdQuery : IRequest<LightNovelDetailDto>
{
    public int LightNovelId { get; set; }
}