using LightNovelLibrary.Modules.LightNovel.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Application.Dtos;

public class LightNovelDetailDto
{
    public int LightNovelId { get; set; }

    public string Name { get; set; } = string.Empty;

    public LightNovelStatus Status { get; set; }

    public DateTime UpdateTime { get; set; }

    public AuthorDto? Author { get; set; }

    public List<TagDto> Tags { get; set; } = new List<TagDto>();

}

public class AuthorDto
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = string.Empty;
}

public class TagDto
{
    public int TagId { get; set; }

    public string Name { get; set; } = string.Empty;
}

