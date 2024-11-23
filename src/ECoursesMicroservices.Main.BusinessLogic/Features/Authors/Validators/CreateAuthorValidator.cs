using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
{
    private readonly IAuthorService _authorService;

    public CreateAuthorValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.UserId)))
            .MustAsync(async (userId, token) => !await _authorService.IsAuthorUserIdExists(userId, token))
            .When(x => x.UserId != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => Resources.AuthorValidatorsResources.Author_UserId_AlreadyExists);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.FirstName)));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.LastName)));
    }
}
