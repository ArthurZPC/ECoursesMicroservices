using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class GetVideoByIdQueryValidator : AbstractValidator<GetVideoByIdQuery>
{
    private readonly IVideoService _videoService;

    public GetVideoByIdQueryValidator(IVideoService videoService)
    {
        _videoService = videoService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_videoService.IsVideoExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(VideoValidatorsResources.Video_VideoId_NotFound, x.Id));
    }
}
