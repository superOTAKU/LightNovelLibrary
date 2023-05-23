using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;

public class GetLightNovelByIdHandler : IRequestHandler<GetLightNovelByIdQuery, LightNovelDetailDto>
{
    public Task<LightNovelDetailDto> Handle(GetLightNovelByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.LightNovelId;
        return Task.FromResult(new LightNovelDetailDto 
        {
            LightNovelId = id,
            Name = "One Piece",
        });
    }
}

