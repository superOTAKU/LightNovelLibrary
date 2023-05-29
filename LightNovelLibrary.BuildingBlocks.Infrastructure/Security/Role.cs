namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class Role : IRole
{
    public Role(string category, string name)
    {
        Category = category;
        Name = name;
        IRole.Register(category, name, this);
    }

    public Role(string category, string name, IRole child)
    {
        Category = category;
        Name = name;
        AddChild(child);
        IRole.Register(category, name, this);   
    }

    public Role(string category, string name, ISet<IRole> children)
    {
        Category = category;
        Name = name;
        AddChildren(children);
        IRole.Register(category, name, this);
    }

    public string Category { get; init; }

    public string Name { get; init; }

    public string FullName { get => $"{Category}_{Name}"; }


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

