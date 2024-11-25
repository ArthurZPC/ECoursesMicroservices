using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using ECoursesMicroservices.Video.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Services;
public class VideoService : IVideoService
{
    private readonly ECoursesVideoContext _context;
    private readonly IFileService _fileService;
    public VideoService(ECoursesVideoContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public void DeleteVideoData(string basePath, Data.Entities.Video video)
    {
        var previewFilePath = Path.Combine(basePath, video.PreviewImageUrl);
        var videoFilePath = Path.Combine(basePath, video.Url);

        if (File.Exists(previewFilePath))
        {
            _fileService.Delete(previewFilePath);
        }

        if (File.Exists(videoFilePath))
        {
            _fileService.Delete(videoFilePath);
        }
    }
    public async Task<VideoDataDto> UploadVideoDataAsync(string basePath, IFormFile previewImage, IFormFile video)
    {
        var previewImageFileName = _fileService.GenerateRandomFileName(previewImage.FileName);
        var videoFileName = _fileService.GenerateRandomFileName(video.FileName);

        var previewImagePath = Path.Combine(basePath, previewImageFileName);
        var videoPath = Path.Combine(basePath, videoFileName);

        await _fileService.UploadFormFileAsync(previewImage, previewImagePath);
        await _fileService.UploadFormFileAsync(video, videoPath);

        return new VideoDataDto
        {
            PreviewImageUrl = previewImageFileName,
            Url = videoFileName,
        };
    }

    public async Task<bool> IsVideoCoursesExists(Guid courseId, CancellationToken cancellationToken)
    {
        return await _context.Videos.AnyAsync(x => x.CourseId == courseId);
    }

    public async Task<bool> IsVideoExists(Guid videoId, CancellationToken cancellationToken)
    {
        return await _context.Videos.AnyAsync(x => x.Id == videoId);
    }

    public async Task<bool> IsVideoExists(Guid videoId, Guid courseId, CancellationToken cancellationToken)
    {
        return await _context.Videos.AnyAsync(x => x.Id == videoId && x.CourseId == courseId);
    }
}
