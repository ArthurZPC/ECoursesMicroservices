using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators;
public class GetCourseByIdValidator : AbstractValidator<GetCourseByIdQuery>
{
    private readonly ECoursesContext _context;

    public GetCourseByIdValidator(ECoursesContext context)
    {
        _context = context;

        RuleFor(x => x.Id)
            .MustAsync(CourseExists)
            .WithMessage(x => string.Format(Resources.CourseValidatorsResources.CourseId_NotFound, x.Id));
    }

    private async Task<bool> CourseExists(Guid id, CancellationToken token)
    {
        return await _context.Courses.AnyAsync(x => x.Id == id);
    }
}
