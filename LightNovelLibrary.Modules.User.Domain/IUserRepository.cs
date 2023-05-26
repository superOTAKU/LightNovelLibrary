using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.User.Domain;

public interface IUserRepository : IRepository
{
    void AddUser(User user);

    User GetUserById(int id);

    void AddUserLightNovel(UserLightNovel userLightNovel);

    bool IsUserExists(string UserName);

    User? GetUserByUserName(string UserName);

}

