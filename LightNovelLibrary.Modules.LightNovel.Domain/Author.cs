namespace LightNovelLibrary.Modules.LightNovel.Domain;

/// <summary>
/// 作者
/// </summary>
public class Author
{
    public int AuthorId { get; set; }

    public string Name { get; set; } = string.Empty;

    public Gender Gender { get; set; }

}

public enum Gender
{
    Male,
    Female
}

