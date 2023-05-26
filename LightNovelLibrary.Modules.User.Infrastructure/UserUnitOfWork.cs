using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using MediatR;

namespace LightNovelLibrary.Modules.User.Infrastructure;

public class UserUnitOfWork : UnitOfWork
{

    public UserUnitOfWork(UserDbContext context, IMediator mediator) : base(context, mediator)
    {
        
    }

}

