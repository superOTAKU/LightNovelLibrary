namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 单行本
/// </summary>
public class Edition
{
    public int EditionId { get; set; }

    public int LightNovelId { get; set; }

    public LightNovel LightNovel { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public ICollection<Chaptor> Chaptors { get; set; } = new List<Chaptor>();

}

