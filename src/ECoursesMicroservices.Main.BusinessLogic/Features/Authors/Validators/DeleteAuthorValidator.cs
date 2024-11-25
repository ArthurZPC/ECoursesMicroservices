using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class DeleteAuthorValidator : AbstractValidator<DeleteAuthorCommand>
{
    private readonly IAuthorService _authorService;

    public DeleteAuthorValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, x.Id))
            .MustAsync(_authorService.IsAuthorExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.Author_AuthorId_NotFound, x.Id));
    }
}
