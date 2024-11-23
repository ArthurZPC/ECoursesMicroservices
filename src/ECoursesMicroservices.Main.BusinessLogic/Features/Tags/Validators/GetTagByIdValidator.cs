using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
using ECoursesMicroservices.Main.Data;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Validators;
public class GetTagByIdValidator : AbstractValidator<GetTagByIdQuery>
{
    private readonly ITagService _tagService;

    public GetTagByIdValidator(ITagService tagService)
    {
        _tagService = tagService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_tagService.IsTagExists)
            .When(x => x.Id != default)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.Tag_TagId_NotFound, x.Id));
    }
}
