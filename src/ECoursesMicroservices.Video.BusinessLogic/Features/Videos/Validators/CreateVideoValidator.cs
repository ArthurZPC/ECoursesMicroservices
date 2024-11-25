using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class CreateVideoValidator : AbstractValidator<CreateVideoCommand>
{
    private readonly IVideoService _videoService;

    public CreateVideoValidator(IVideoService videoService)
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

        RuleFor(x => x.PreviewImage)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.PreviewImage)));

        RuleFor(x => x.Video)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Video)));
    }
}
