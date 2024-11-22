
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdQuery>
{
    private readonly ECoursesContext _context;
    public GetAuthorByIdValidator(ECoursesContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(AuthorExists)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.AuthorId_NotFound, x.Id));
    }

    private async Task<bool> AuthorExists(Guid id, CancellationToken token)
    {
        return await _context.Authors.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
