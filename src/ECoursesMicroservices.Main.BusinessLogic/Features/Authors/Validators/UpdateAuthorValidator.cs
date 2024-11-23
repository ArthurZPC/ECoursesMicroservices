using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
{
    private readonly IAuthorService _authorService;

    public UpdateAuthorValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.Id)
            .MustAsync(_authorService.IsAuthorExists)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.Author_AuthorId_NotFound, x.Id));

        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
    }
}
