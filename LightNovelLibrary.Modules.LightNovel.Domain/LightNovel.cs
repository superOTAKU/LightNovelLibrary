using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 小说，聚合根
/// </summary>
public class LightNovel : BaseEntity, IAggregateRoot
{
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