using LightNovelLibrary.BuildingBlocks.Domain;
using X = LightNovelLibrary.Modules.User.Domain;

namespace LightNovelLibrary.Modules.User.Application.Events;

public class UserCreatedEvent : DomainEventBase
{
    public UserCreatedEvent(X.User user)
    {
        User = user;
    }

    public X.User User { get; init; }
}

