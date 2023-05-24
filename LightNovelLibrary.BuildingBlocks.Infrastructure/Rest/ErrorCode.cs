namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

/// <summary>
/// 全局应用错误码，需要统一定义不重复，所以只能放到infrastructure
/// </summary>
public enum ErrorCode : int
{
   AuthorNotExists = 1,
   TagNotExist = 2,
   LightNovelNotExists = 3
}

