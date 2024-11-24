using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
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
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_courseService.IsCourseExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.CourseValidatorsResources.Course_CourseId_NotFound, x.Id));
    }
}
