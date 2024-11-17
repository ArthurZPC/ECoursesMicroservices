namespace ECoursesMicroservices.Infrastructure.Models;
public class ApiError
{
    public int StatusCode { get; set; }

    public string ErrorMessage { get; set; } = string.Empty;
}
