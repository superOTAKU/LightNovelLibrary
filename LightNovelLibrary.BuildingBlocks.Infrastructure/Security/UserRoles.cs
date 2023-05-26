namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class UserRoles
{
    public static readonly IRole User = new Role(PrincipalType.User, "User");

}

