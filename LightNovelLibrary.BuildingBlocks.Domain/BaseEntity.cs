namespace LightNovelLibrary.BuildingBlocks.Domain;

public abstract class BaseEntity : IEntity
{
    private IList<IDomainEvent> _events = new List<IDomainEvent>();

    public IList<IDomainEvent> DomainEvents => _events;

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public IList<IDomainEvent> PollDomainEvents()
    {
        var events = _events;
        _events = new List<IDomainEvent>();
        return events;
    }
}

