using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Validators;
public class DeleteTagValidator : AbstractValidator<DeleteTagCommand>
{
    private readonly ITagService _tagService;

    public DeleteTagValidator(ITagService tagService)
    {
        _tagService = tagService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_tagService.IsTagExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagId_NotFound, x.Id));
    }
}
