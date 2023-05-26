using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.Modules.User.Domain;

namespace LightNovelLibrary.Modules.User.Infrastructure;
public class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;
    private readonly UserUnitOfWork _unitOfWork;

    public UserRepository(UserDbContext context, UserUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork => _unitOfWork;

    public void AddUser(Domain.User user)
    {
        _context.Users.Add(user);
    }

    public void AddUserLightNovel(UserLightNovel userLightNovel)
    {
        throw new NotImplementedException();
    }

    public Domain.User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Domain.User? GetUserByUserName(string UserName)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == UserName);
    }

    public bool IsUserExists(string UserName)
    {
        return _context.Users.Any(u => u.UserName == UserName);
    }
}
