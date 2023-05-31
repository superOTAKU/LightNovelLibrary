namespace LightNovelLibrary.Modules.Admins.Domains;

/// <summary>
/// Admin领域内的LightNovel对象，需要什么属性取决于当前模块和LightNovel的交互程度，也可能会完全相同
/// </summary>
public class LightNovel
{
    public int LightNovelId { get; set; }

    public string Name { get; set; } = null!;
}

