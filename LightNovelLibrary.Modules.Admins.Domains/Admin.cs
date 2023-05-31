using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.Admins.Domains;
public class Admin : EntityBase, IAggregateRoot
{
    public int AdminId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime UpdateTime { get; set; }

}
