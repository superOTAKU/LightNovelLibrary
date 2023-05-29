namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class Role : IRole
{
    public Role(string name)
    {
        Name = name;
        IRole.RoleDictionary[name] = this;
    }

    public Role(string name, IRole child)
    {
        Name = name;
        AddChild(child);
        IRole.RoleDictionary[name] = this;
    }

    public Role(string name, ISet<IRole> children)
    {
        Name = name;
        AddChildren(children);
        IRole.RoleDictionary[name] = this;
    }

    public string Name { get; init; }

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

