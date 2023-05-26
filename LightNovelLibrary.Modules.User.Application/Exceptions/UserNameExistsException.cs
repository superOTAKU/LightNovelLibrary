using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.User.Application.Exceptions;

public class UserNameExistsException : Rest.BusinessException
{
    public UserNameExistsException(string userName)
        : base((int)Rest.ErrorCode.UserNameExists, $"UserName {userName} Already Exists")
    {
        
    }
}

