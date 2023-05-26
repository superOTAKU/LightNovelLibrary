using Rest = LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

namespace LightNovelLibrary.Modules.User.Application.Exceptions;

public class PasswordNotMatchException : Rest.BusinessException
{
    public PasswordNotMatchException()
        : base((int)Rest.ErrorCode.PasswordNotMatch, "Password Not Match")
    {
        
    }
}

