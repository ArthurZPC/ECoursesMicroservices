using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
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
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Name)))
            .MustAsync(async (name, token) => !await _tagService.IsTagExists(name, token))
            .When(x => !string.IsNullOrEmpty(x.Name), ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagName_AlreadyExists, x.Name));
    }
}
