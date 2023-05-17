namespace LightNovelLibrary.BuildingBlocks.Domain;

public interface IDomainEventHandler<TDomainEvent> where TDomainEvent : IDomainEvent
{

    Task Handle(TDomainEvent domainEvent);

}

