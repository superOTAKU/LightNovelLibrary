namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class UserRoles
{
    public static readonly IRole User = new Role(UserRoleNames.User);

    //静态构造函数
    static UserRoles()
    {
        //确保所有的静态域被正确地初始化！！！
    }

}

public class UserRoleNames
{
    //分类_权限
    public const string User = "User_User";
}

