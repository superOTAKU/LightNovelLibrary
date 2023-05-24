using LightNovelLibrary.Modules.LightNovel.Application.Exceptions;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;

public class AddLightNovelCommandHandler : IRequestHandler<AddLightNovelCommand, int>
{
    private readonly ILightNovelRepository _repository;

    public AddLightNovelCommandHandler(ILightNovelRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(AddLightNovelCommand request, CancellationToken cancellationToken)
    {
        if (!_repository.IsAuthorExists(request.AuthorId))
        {
            throw new AuthorNotExistsException(request.AuthorId);
        }
        if (!_repository.IsTagsExist(request.TagIds))
        {
            throw new TagNotExistException(request.TagIds);
        }

        var lightNovel = new Domain.LightNovel
        {
            Name = request.Name,
            Status = request.Status,
            AuthorId = request.AuthorId,
            Tags = _repository.GetTags(request.TagIds).ToList()
        };
        _repository.Add(lightNovel);
        await _repository.UnitOfWork.CommitAsync(cancellationToken);
        return lightNovel.LightNovelId;
    }
}

