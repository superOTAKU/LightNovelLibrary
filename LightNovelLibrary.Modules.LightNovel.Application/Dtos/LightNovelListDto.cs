using LightNovelLibrary.Modules.LightNovel.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Application.Dtos;

public class LightNovelListDto
{
    public int LightNovelId { get; set; }

    public string Name { get; set; } = string.Empty;

    public LightNovelStatus Status { get; set; }

    public DateTime UpdateTime { get; set; }

    public int AuthorId { get; set; }
}

