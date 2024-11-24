using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Validators;
public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
{
    private readonly ITagService _tagService;

    public UpdateTagValidator(ITagService tagService)
    {
        _tagService = tagService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_tagService.IsTagExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagId_NotFound, x.Id));

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Name)))
            .MustAsync(async (name, token) => !await _tagService.IsTagExists(name, token))
            .When(x => !string.IsNullOrEmpty(x.Name), ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagName_AlreadyExists, x.Name));
    }
}
