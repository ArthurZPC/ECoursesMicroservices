using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.Helpers;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands.Handlers;
public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand>
{
    private readonly ECoursesVideoContext _context;
    private readonly IValidator<DeleteVideoCommand> _validator;
    private readonly WebRootPathExtractor _webRootPathExtractor;
    private readonly IVideoService _videoService;

    public DeleteVideoCommandHandler(ECoursesVideoContext context,
        IValidator<DeleteVideoCommand> validator,
        WebRootPathExtractor webRootPathExtractor,
        IVideoService videoService)
    {
        _context = context;
        _validator = validator;
        _webRootPathExtractor = webRootPathExtractor;
        _videoService = videoService;
    }

    public async Task Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var videoToDelete = await _context.Videos.FindAsync(request.Id);

        var basePath = _webRootPathExtractor.GetWebRootPath();
        _videoService.DeleteVideoData(basePath, videoToDelete!);

        _context.Videos.Remove(videoToDelete!);

        await _context.SaveChangesAsync();
    }
}
