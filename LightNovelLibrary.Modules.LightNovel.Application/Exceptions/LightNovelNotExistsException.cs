using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.LightNovel.Application.Exceptions;

[HttpStatus(System.Net.HttpStatusCode.NotFound)]
public class LightNovelNotFoundException : Rest.BusinessException
{
    public LightNovelNotFoundException(int lightNovelId)
        : base((int)Rest.ErrorCode.LightNovelNotExists, $"light novel {lightNovelId} not exists")
    {
    }

}

