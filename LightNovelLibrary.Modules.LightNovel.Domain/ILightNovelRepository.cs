using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Domain;

public interface ILightNovelRepository : IRepository
{
    LightNovel? GetById(int lightNovelId);

    void Add(LightNovel lightNovel);

    Author? GetAuthorById(int authorId);

    bool IsAuthorExists(int authorId);

    bool IsTagsExist(IEnumerable<int> tagIds);

    IEnumerable<Tag> GetTags(IEnumerable<int> tagIds);

}

