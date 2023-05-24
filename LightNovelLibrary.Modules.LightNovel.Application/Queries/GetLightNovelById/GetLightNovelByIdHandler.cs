using LightNovelLibrary.Modules.LightNovel.Application.Dtos;
using LightNovelLibrary.Modules.LightNovel.Application.Exceptions;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Queries.GetLightNovelById;

public class GetLightNovelByIdHandler : IRequestHandler<GetLightNovelByIdQuery, LightNovelDetailDto>
{
    private readonly ILightNovelRepository _repository;

    public GetLightNovelByIdHandler(ILightNovelRepository repository)
    {
        _repository = repository;
    }

    public Task<LightNovelDetailDto> Handle(GetLightNovelByIdQuery request, CancellationToken cancellationToken)
    {
        var lightNovel = _repository.GetById(request.LightNovelId);
        if (lightNovel == null)
        {
            throw new LightNovelNotExistsException(request.LightNovelId);
        }
        return Task.FromResult(new LightNovelDetailDto
        {
            LightNovelId = lightNovel.LightNovelId,
            Name = lightNovel.Name,
            Status = lightNovel.Status,
            Author = new AuthorDto
            {
                AuthorId = lightNovel.AuthorId,
                Name = lightNovel.Author?.Name ?? string.Empty
            },
            Tags = lightNovel.Tags.Select(t => new TagDto
            {
                TagId = t.TagId,
                Name = t.Name
            }).ToList()
        });
    }
}

