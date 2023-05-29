namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

/// <summary>
/// 带层级角色权限
/// 设计参考：https://dev.to/kirekov/spring-security-and-non-flat-roles-inheritance-architecture-2a7b
/// </summary>
public interface IRole
{

    #region 属性
    //角色类型
    string Category { get; }

    //角色名称
    string Name { get; }

    string FullName { get; }
    #endregion

    #region 方法

    /// <summary>
    ///   当前角色是否包含目标角色
    /// </summary>
    /// <param name="role">待检测的角色</param>
    /// <returns></returns>
    bool Includes(IRole role);

    #endregion

    #region 工具方法和静态域

    /// <summary>
    ///  顶层的角色，我们的职责是构建出不同的顶层角色，例如：
    ///  普通用户，VIP用户，管理员...
    ///  如果管理员包含了其他角色，则顶层就只有管理员...
    /// </summary>
    static ISet<IRole> Roots { get; } = new HashSet<IRole>()
    {
        UserRoles.User,
        AdminRoles.Admin
    };

    static IDictionary<string, IRole>? _roleDictionary;


    static IDictionary<string, IRole> RoleDictionary 
    {
        get
        {
            if (_roleDictionary == null)
            {
                _roleDictionary = new Dictionary<string, IRole>();
            }
            return _roleDictionary;
        }
    }

    static IRole GetRole(string category, string name)
    {
        return RoleDictionary[$"{category}_{name}"];
    }

    static IRole GetRole(string fullName)
    {
        var (category, name) = SplitRoleName(fullName);
        return GetRole(category, name);
    }

    static void Register(string category, string name, IRole role)
    {
        RoleDictionary[$"{category}_{name}"] = role;
    }

    static (string, string) SplitRoleName(string role)
    {
        var parts = role.Split('_');
        return (parts[0], parts[1]);
    }

    static string GetFullName(string category, string name)
    {
        return $"{category}_{name}";
    }

    #endregion

}

