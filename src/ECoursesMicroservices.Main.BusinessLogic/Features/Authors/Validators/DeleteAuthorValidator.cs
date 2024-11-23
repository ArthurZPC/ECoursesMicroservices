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
            .MustAsync(_authorService.IsAuthorExists)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.Author_AuthorId_NotFound, x.Id));
    }
}
