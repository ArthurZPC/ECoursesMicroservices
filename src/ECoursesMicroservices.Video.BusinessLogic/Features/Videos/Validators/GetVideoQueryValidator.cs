using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class GetVideoQueryValidator : AbstractValidator<GetVideoQuery>
{
    private readonly IVideoService _videoService;
    public GetVideoQueryValidator(IVideoService videoService)
    {
        _videoService = videoService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required,nameof(x.Id)));

        RuleFor(x => x.CourseId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.CourseId)));

        RuleFor(x => x)
            .MustAsync(async (video, token) => await _videoService.IsVideoExists(video.Id, video.CourseId, token))
            .When(x => x.CourseId != default && x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(VideoValidatorsResources.Video_Ids_NotFound, x.Id, x.CourseId));
    }
}
