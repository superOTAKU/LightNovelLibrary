using LightNovelLibrary.BuildingBlocks.Domain;
using MediatR;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(AppDbContext context, IMediator mediator)
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



