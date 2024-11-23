using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
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
            .MustAsync(_tagService.IsTagExists)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagId_NotFound, x.Id));
    }
}
