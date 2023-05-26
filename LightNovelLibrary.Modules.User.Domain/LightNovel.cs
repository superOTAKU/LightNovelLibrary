namespace LightNovelLibrary.Modules.User.Domain;

/// <summary>
/// User Domain内的轻小说实体，甚至可以只存在Id
/// </summary>
public class LightNovel
{
    public int LightNovelId { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new List<User>();

    public ICollection<UserLightNovel> UserLightNovels { get; set; } = new List<UserLightNovel>();
}

