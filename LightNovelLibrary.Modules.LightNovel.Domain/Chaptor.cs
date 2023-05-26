namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 章节
/// </summary>
public class Chaptor
{
    public int ChaptorId { get; set; }

    public int LightNovelId { get; set; }

    public LightNovel LightNovel { get; set; } = null!;

    public int EditionId { get; set; }

    public Edition Edition { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

}

