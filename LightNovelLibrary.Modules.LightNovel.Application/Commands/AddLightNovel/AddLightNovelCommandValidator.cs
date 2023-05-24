using FluentValidation;

namespace LightNovelLibrary.Modules.LightNovel.Application.Commands.AddLightNovel;

public class AddLightNovelCommandValidator : AbstractValidator<AddLightNovelCommand>
{

    public AddLightNovelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Status).IsInEnum();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.TagIds).NotNull();

}

