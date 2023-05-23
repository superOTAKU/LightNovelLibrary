using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;

public class AddLightNovelCommandHandler : IRequestHandler<AddLightNovelCommand, int>
{
    public Task<int> Handle(AddLightNovelCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Add LightNovel: {request}");
        return Task.FromResult(0);
    }
}

