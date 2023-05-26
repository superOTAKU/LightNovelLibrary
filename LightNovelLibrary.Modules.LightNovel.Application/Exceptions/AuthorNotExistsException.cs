using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.LightNovel.Application.Exceptions;

[HttpStatus(System.Net.HttpStatusCode.NotFound)]
public class AuthorNotExistsException : BusinessException
{
    public AuthorNotExistsException(int authorId)
        : base((int)Rest.ErrorCode.AuthorNotExists, $"author {authorId} not exists")
    {
    }

}

