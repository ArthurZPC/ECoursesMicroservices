using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
{
    private readonly IAuthorService _authorService;

    public UpdateAuthorValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_authorService.IsAuthorExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.Author_AuthorId_NotFound, x.Id));

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.FirstName)));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.LastName)));
    }
}
