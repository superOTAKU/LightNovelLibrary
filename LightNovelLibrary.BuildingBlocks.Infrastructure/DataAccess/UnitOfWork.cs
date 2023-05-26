using LightNovelLibrary.BuildingBlocks.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;

public abstract class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(DbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        //发布领域事件
        await Task.WhenAll(_context.ChangeTracker.Entries()
            .Select(e => e.Entity)
            .OfType<IEntity>()
            .SelectMany(e => e.PollDomainEvents())
            .Select(e => _mediator.Publish(e)));
        await _context.SaveChangesAsync(cancellationToken);
    }

}



