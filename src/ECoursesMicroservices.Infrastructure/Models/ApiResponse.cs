namespace ECoursesMicroservices.Infrastructure.Models;
public class ApiResponse<T>
{
    public T? Data { get; set; }

    public List<ApiError> Errors { get; set; } = new List<ApiError>();
}
