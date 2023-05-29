namespace LightNovelLibrary.BuildingBlocks.Domain;

public abstract class DomainEventBase : IDomainEvent
{
    private readonly DateTime _occurredOn;
    private readonly Guid _guid;

    public DomainEventBase()
    {
        _occurredOn = DateTime.UtcNow;
        _guid = Guid.NewGuid();
    }

    public Guid Guid { get => _guid;}

    public DateTime OccurredOn { get => _occurredOn;}

}

