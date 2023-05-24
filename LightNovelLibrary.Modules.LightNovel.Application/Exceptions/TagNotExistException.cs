using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.LightNovel.Application.Exceptions;

public class TagNotExistException : Rest.BusinessException
{

    public TagNotExistException(IEnumerable<int> tagIds)
        : base((int)Rest.ErrorCode.TagNotExist, $"some tag id is not exists : [{string.Join(", ", tagIds)}]")
    {
        
    }

}

