using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators;
public class DeleteCourseValidator : AbstractValidator<DeleteCourseCommand>
{
    private readonly ICourseService _courseService;
    public DeleteCourseValidator(ICourseService courseService)
    {
        _courseService = courseService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(_courseService.IsCourseExists)
            .WithMessage(x => string.Format(Resources.CourseValidatorsResources.Course_CourseId_NotFound, x.Id));
    }
}
