using MediatR;

namespace LightNovelLibrary.Modules.User.Application.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Unit>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}

