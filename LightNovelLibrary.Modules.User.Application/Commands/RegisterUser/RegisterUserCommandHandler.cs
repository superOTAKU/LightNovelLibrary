using LightNovelLibrary.Modules.User.Application.Exceptions;
using X = LightNovelLibrary.Modules.User.Domain;
using LightNovelLibrary.Modules.User.Domain;
using MediatR;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

namespace LightNovelLibrary.Modules.User.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
{
    private readonly IUserRepository _repository;
    private readonly IPasswordManager _passwordManager;

    public RegisterUserCommandHandler(IUserRepository repository, IPasswordManager passwordManager)
    {
        _repository = repository;
        _passwordManager = passwordManager;
    }

    public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (_repository.IsUserExists(request.UserName))
        {
            throw new UserNameExistsException(request.UserName);
        }
        var passwordHashed = _passwordManager.Hash(() => request.Password);
        var user = X.User.RegisterNewUser(request.UserName, passwordHashed);
        _repository.AddUser(user);
        await _repository.UnitOfWork.CommitAsync(cancellationToken);
        return Unit.Value;
    }
}

