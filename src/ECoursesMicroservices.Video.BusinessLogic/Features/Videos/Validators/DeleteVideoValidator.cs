using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators.Resources;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
public class DeleteVideoValidator : AbstractValidator<DeleteVideoCommand>
{
    private readonly IVideoService _videoService;

    public DeleteVideoValidator(IVideoService videoService)
    {
        _videoService = videoService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_videoService.IsVideoExists)
            .WithMessage(x => string.Format(VideoValidatorsResources.Video_CourseId_NotFound, x.Id));
    }
}
