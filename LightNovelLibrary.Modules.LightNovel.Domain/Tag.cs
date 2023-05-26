namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 标签
/// </summary>
public class Tag
{
    public int TagId { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<LightNovel> LightNovels { get; set; } = new List<LightNovel>();

    public ICollection<LightNovelTag> LightNovelTags { get; set; } = new List<LightNovelTag>();
}

