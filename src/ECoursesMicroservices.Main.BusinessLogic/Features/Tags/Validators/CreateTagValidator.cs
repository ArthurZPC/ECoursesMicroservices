using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Validators;
public class CreateTagValidator : AbstractValidator<CreateTagCommand>
{
    private readonly ITagService _tagService;

    public CreateTagValidator(ITagService tagService)
    {
        _tagService = tagService;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MustAsync(async (name, token) => !await _tagService.IsTagExists(name, token))
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagName_AlreadyExists, x.Name));
    }
}
