using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Domain.Events;

public class LightNovelCreatedEvent : DomainEventBase
{

    public LightNovelCreatedEvent(LightNovel lightNovel)
    {
        LightNovel = lightNovel;
    }

    public LightNovel LightNovel { get; init; }
}

