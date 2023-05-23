namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 小说
/// </summary>
public class LightNovel
{
    public int LightNovelId { get; set; }

    public string Name { get; set; } = string.Empty;

    public LightNovelStatus Status { get; set; }

    public DateTime UpdateTime { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public List<Tag> Tags { get; set; } = new List<Tag>();

    public List<Edition> Editions { get; set; } = new List<Edition>();

    public List<Chaptor> Chaptors { get; set; } = new List<Chaptor>();
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