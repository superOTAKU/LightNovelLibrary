namespace LightNovelLibrary.Modules.User.Domain;

public class UserLightNovel
{
    public int UserId { get; set; }

    public int LightNovelId { get; set; }

    public User User { get; set; } = null!;

    public LightNovel LightNovel { get; set; } = null!;

}

