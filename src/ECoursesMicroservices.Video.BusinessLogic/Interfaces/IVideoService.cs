using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECoursesMicroservices.Video.BusinessLogic.Interfaces;
public interface IVideoService
{
    Task<bool> IsVideoExists(Guid videoId, CancellationToken cancellationToken);
    Task<bool> IsVideoExists(Guid videoId, Guid courseId, CancellationToken cancellationToken);
    Task<bool> IsVideoCoursesExists(Guid courseId, CancellationToken cancellationToken);

    void DeleteVideoData(string basePath, Data.Entities.Video video);
    Task<VideoDataDto> UploadVideoDataAsync(string basePath, IFormFile previewImage, IFormFile video);
}
