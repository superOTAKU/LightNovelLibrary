namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class AdminRoles
{
    public static readonly IRole Admin = new Role(AdminRoleNames.Admin);
}

public class AdminRoleNames
{
    public const string Admin = "Admin_Admin";

}

