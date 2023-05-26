using LightNovelLibrary.Modules.User.Application.Exceptions;
using X = LightNovelLibrary.Modules.User.Domain;
using LightNovelLibrary.Modules.User.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.User.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly IUserRepository _repository;

    public RegisterUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (_repository.IsUserExists(request.UserName))
        {
            throw new UserNameExistsException(request.UserName);
        }
        var user = new X.User
        {
            UserName = request.UserName,
            Password = request.Password,
            CreateTime = DateTime.UtcNow,
            UpdateTime = DateTime.UtcNow
        };
        _repository.AddUser(user);
        await _repository.UnitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}

