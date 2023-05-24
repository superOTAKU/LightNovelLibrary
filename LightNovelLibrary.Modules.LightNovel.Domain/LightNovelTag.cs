namespace LightNovelLibrary.Modules.LightNovel.Domain;

public class LightNovelTag
{
    public int LightNovelId { get; set; }
    public int TagId { get; set; }

    public LightNovel LightNovel { get; set; } = null!;

    public Tag Tag { get; set; } = null!;
}

