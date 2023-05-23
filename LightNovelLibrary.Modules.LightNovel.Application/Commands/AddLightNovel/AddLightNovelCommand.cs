using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;

namespace LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;

public class AddLightNovelCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;

    public LightNovelStatus Status { get; set; }

    public int AuthorId { get; set; }

    public List<int> TagIds { get; set; } = new List<int>();


    public override string ToString()
    {
        return $"AddLightNovelCommand(Name={Name}, Status={Status}, AuthorId={AuthorId}, TagIds=[{string.Join(", ", TagIds)}])";
    }

}

