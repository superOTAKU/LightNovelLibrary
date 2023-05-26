using LightNovelLibrary.Modules.User.Application.Dtos;
using MediatR;

namespace LightNovelLibrary.Modules.User.Application.Commands.UserLogin;

public class UserLoginCommand : IRequest<AuthenticationTokenDto>
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}

