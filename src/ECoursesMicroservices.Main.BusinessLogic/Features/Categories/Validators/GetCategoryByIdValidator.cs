using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
{
    private readonly ECoursesContext _context;
    public GetCategoryByIdValidator(ECoursesContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(CategoryExists)
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.CategoryId_NotFound, x.Id));
    }

    private async Task<bool> CategoryExists(Guid id, CancellationToken token)
    {
        return await _context.Categories.AsNoTracking().AnyAsync(x => x.Id == id);
    }
}
