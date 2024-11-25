using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.Helpers;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands.Handlers;
public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand>
{
    private readonly ECoursesVideoContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateVideoCommand> _validator;
    private readonly WebRootPathExtractor _webRootPathExtractor;
    private readonly IVideoService _videoService;

    public CreateVideoCommandHandler(ECoursesVideoContext context,
        IMapper mapper,
        IValidator<CreateVideoCommand> validator,
        WebRootPathExtractor webRootPathExtractor,
        IVideoService videoService)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
        _webRootPathExtractor = webRootPathExtractor;
        _videoService = videoService;
    }

    public async Task Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var video = _mapper.Map<Data.Entities.Video>(request);

        var basePath = _webRootPathExtractor.GetWebRootPath();

        var videoData = await _videoService.UploadVideoDataAsync(basePath, request.PreviewImage, request.Video);

        video.PreviewImageUrl = videoData.PreviewImageUrl;
        video.Url = videoData.Url;

        _context.Videos.Add(video);

        await _context.SaveChangesAsync();
    }
}
