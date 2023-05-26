using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.BuildingBlocks.Domain.Pagination;

namespace LightNovelLibrary.Modules.LightNovel.Domain;

public interface ILightNovelRepository : IRepository
{
    LightNovel? GetById(int lightNovelId);

    LightNovel? GetById(int lightNovelId, GetLightNovelOptions? options);

    PaginationResult<LightNovel> GetLightNovelPage(LightNovelPaginationQuery query);

    void Add(LightNovel lightNovel);

    Author? GetAuthorById(int authorId);

    bool IsAuthorExists(int authorId);

    bool IsTagsExist(IEnumerable<int> tagIds);

    IEnumerable<Tag> GetTags(IEnumerable<int> tagIds);

}

/// <summary>
/// 获取Novel选项
/// </summary>
public class GetLightNovelOptions
{
    public bool IncludeTags { get; set; } = true;

    public bool IncludeAuthor { get; set; } = true;
}

public class LightNovelPaginationQuery : PaginationQuery
{
    public int? AuthorId { get; set;}
}
