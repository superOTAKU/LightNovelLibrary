using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.LightNovel.Application.Exceptions;

[HttpStatus(System.Net.HttpStatusCode.NotFound)]
public class TagNotExistException : BusinessException
{

    public TagNotExistException(IEnumerable<int> tagIds)
        : base((int)Rest.ErrorCode.TagNotExist, $"some tag id is not exists : [{string.Join(", ", tagIds)}]")
    {
        
    }

}

