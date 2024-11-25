using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.Helpers;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands.Handlers;
public class DeleteCourseVideosCommandHandler : IRequestHandler<DeleteCourseVideosCommand>
{
    private readonly ECoursesVideoContext _context;
    private readonly IValidator<DeleteCourseVideosCommand> _validator;
    private readonly WebRootPathExtractor _webRootPathExtractor;
    private readonly IVideoService _videoService;

    public DeleteCourseVideosCommandHandler(ECoursesVideoContext context,
        IValidator<DeleteCourseVideosCommand> validator,
        WebRootPathExtractor webRootPathExtractor,
        IVideoService videoService)
    {
        _context = context;
        _validator = validator;
        _webRootPathExtractor = webRootPathExtractor;
        _videoService = videoService;
    }

    public async Task Handle(DeleteCourseVideosCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var videosToDelete = await _context.Videos
            .Where(x => x.CourseId == request.CourseId)
            .ToListAsync();

        var basePath = _webRootPathExtractor.GetWebRootPath();

        foreach (var video in videosToDelete)
        {
            _videoService.DeleteVideoData(basePath, video);
        }

        _context.Videos.RemoveRange(videosToDelete);

        await _context.SaveChangesAsync();
    }
}
