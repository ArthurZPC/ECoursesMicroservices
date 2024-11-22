using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Validators;
public class GetTagByIdValidator : AbstractValidator<GetTagByIdQuery>
{
    private readonly ECoursesContext _context;

    public GetTagByIdValidator(ECoursesContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .MustAsync(TagExists)
            .WithMessage(x => string.Format(Resources.TagValidatorsResources.TagId_NotFound, x.Id));
    }

    private async Task<bool> TagExists(Guid id, CancellationToken token)
    {
        return await _context.Tags.AnyAsync(x => x.Id == id);
    }
}
