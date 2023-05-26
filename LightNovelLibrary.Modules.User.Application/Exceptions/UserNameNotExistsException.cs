using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.User.Application.Exceptions;

public class UserNameNotExistsException : Rest.BusinessException
{
    public UserNameNotExistsException(string userName)
        : base((int)Rest.ErrorCode.UserNameNotExists, $"UserName {userName} Not Exists")
    {
        
    }
}

