﻿using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators;
public class GetCourseByIdValidator : AbstractValidator<GetCourseByIdQuery>
{
    private readonly ICourseService _courseService;

    public GetCourseByIdValidator(ICourseService courseService)
    {
        _courseService = courseService;

        RuleFor(x => x.Id)
            .MustAsync(_courseService.IsCourseExists)
            .WithMessage(x => string.Format(Resources.CourseValidatorsResources.Course_CourseId_NotFound, x.Id));
    }
}
