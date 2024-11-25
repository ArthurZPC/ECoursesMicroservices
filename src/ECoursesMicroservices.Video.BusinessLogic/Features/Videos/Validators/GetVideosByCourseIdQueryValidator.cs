using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class GetVideosByCourseIdQueryValidator : AbstractValidator<GetVideosByCourseIdQuery>
{
    private readonly IVideoService _videoService;

    public GetVideosByCourseIdQueryValidator(IVideoService videoService)
    {
        _videoService = videoService;

        RuleFor(x => x.CourseId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.CourseId)))
            .MustAsync(_videoService.IsVideoCoursesExists)
            .When(x => x.CourseId != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(VideoValidatorsResources.Video_CourseId_NotFound, x.CourseId));
    }
}
