using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class UpdateVideoValidator : AbstractValidator<UpdateVideoCommand>
{
    private readonly IVideoService _videoService;

    public UpdateVideoValidator(IVideoService videoService)
    {
        _videoService = videoService;

        RuleFor(x => x.CourseId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.CourseId)));

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Title)));

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Description)));
    }
}
