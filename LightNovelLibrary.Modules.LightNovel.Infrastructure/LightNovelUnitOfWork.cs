using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Infrastructure;

public class LightNovelUnitOfWork : UnitOfWork
{
    public LightNovelUnitOfWork(LightNovelDbContext context, IMediator mediator) : base(context, mediator)
    {
    }
}

