using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.User.Domain;

public class User : BaseEntity, IAggregateRoot
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    /// <summary>
    /// 用户收藏的轻小说集合
    /// </summary>
    public ICollection<UserLightNovel> UserLightNovels { get; set;} = new List<UserLightNovel>();

    public ICollection<LightNovel> LightNovels { get; set; } = new List<LightNovel>();
}