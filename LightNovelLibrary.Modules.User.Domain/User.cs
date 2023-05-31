using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.Modules.User.Application.Events;

namespace LightNovelLibrary.Modules.User.Domain;

public class User : EntityBase, IAggregateRoot
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

    public User()
    {
        // EF Core框架使用
    }

    private User(string userName, string password)
    {
        var utcNow = DateTime.UtcNow;
        UserName = userName;
        Password = password;
        CreateTime = utcNow;
        UpdateTime = utcNow;
        //由于用到数据库自增ID，此刻还是没有Id的状态，不过无伤大雅
        AddDomainEvent(new UserCreatedEvent(this));
    }

    public static User RegisterNewUser(string userName, string password)
    {
        return new User(userName, password);
    }

}