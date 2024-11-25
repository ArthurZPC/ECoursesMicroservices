using Microsoft.AspNetCore.Http;

namespace ECoursesMicroservices.Video.BusinessLogic.Interfaces;
public interface IFileService
{
    Task UploadFormFileAsync(IFormFile formFile, string path);
    void Delete(string path);
    void Move(string currentPath, string newPath);
    bool ContainsExtension(string fileName);
    string GetExtension(string fileName);
    string GenerateRandomFileName(string fileName);
}
