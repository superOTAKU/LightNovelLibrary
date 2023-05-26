namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

/// <summary>
/// 带层级角色权限
/// 设计参考：https://dev.to/kirekov/spring-security-and-non-flat-roles-inheritance-architecture-2a7b
/// </summary>
public interface IRole
{
    /// <summary>
    ///   当前角色是否包含目标角色
    /// </summary>
    /// <param name="role">待检测的角色</param>
    /// <returns></returns>
    bool Includes(IRole role);

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

}

