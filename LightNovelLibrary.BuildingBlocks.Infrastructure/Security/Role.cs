namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class Role : IRole
{
    public Role()
    {
    }

    public Role(IRole child)
    {
        AddChild(child);
    }

    public Role(ISet<IRole> children)
    {
        AddChildren(children);
    }

    private readonly ISet<IRole> _children = new HashSet<IRole>();
    public bool Includes(IRole role)
    {
        return role == this || _children.Any(c => c.Includes(role));
    }

    public void AddChild(IRole role)
    {
        _children.Add(role);
    }

    public void AddChildren(ISet<IRole> roles)
    {
        foreach(var role in roles)
        {
            AddChild(role);
        }
    }

}

