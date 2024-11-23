using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
{
    private readonly IAuthorService _authorService;

    public CreateAuthorValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.UserId)
            .NotEmpty()
            .MustAsync(async (userId, token) => !await _authorService.IsAuthorUserIdExists(userId, token))
            .WithMessage(x => Resources.AuthorValidatorsResources.Author_UserId_AlreadyExists);
    }
}
