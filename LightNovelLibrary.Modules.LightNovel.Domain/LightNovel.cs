using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.Modules.LightNovel.Domain.Events;

namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 小说，聚合根
/// </summary>
public class LightNovel : EntityBase, IAggregateRoot
{

    public LightNovel()
    {
        //EF Core
    }

    public int LightNovelId { get; set; }

    public string Name { get; set; } = string.Empty;

    public LightNovelStatus Status { get; set; }

    public DateTime UpdateTime { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public ICollection<LightNovelTag> LightNovelTags { get; set; } = new List<LightNovelTag>();

    public ICollection<Edition> Editions { get; set; } = new List<Edition>();

    public ICollection<Chaptor> Chaptors { get; set; } = new List<Chaptor>();

    /// <summary>
    /// 创建此小说的管理员
    /// </summary>
    public int createdAdminId;

    /// <summary>
    /// 领域逻辑，添加轻小说
    /// </summary>
    public static LightNovel Create(string name, LightNovelStatus status, int authorId, IEnumerable<int> TagIds)
    {
        var novel = new LightNovel
        {
            Name = name,
            Status = status,
            AuthorId = authorId,
            LightNovelTags = TagIds.Select(tagId => new LightNovelTag { TagId = tagId }).ToList(),
            UpdateTime = DateTime.UtcNow
        };
        novel.AddDomainEvent(new LightNovelCreatedEvent(novel));
        return novel;
    }

}

public enum LightNovelStatus
{
    /// <summary>
    /// 连载中
    /// </summary>
    Serializing,
    /// <summary>
    /// 已完结
    /// </summary>
    Completed
}