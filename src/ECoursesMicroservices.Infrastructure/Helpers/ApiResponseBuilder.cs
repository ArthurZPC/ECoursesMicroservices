using ECoursesMicroservices.Infrastructure.Models;

namespace ECoursesMicroservices.Infrastructure.Helpers;
public static class ApiResponseBuilder
{
    public static ApiResponse<T> Create<T>(T? data)
    {
        return new ApiResponse<T> { Data = data };
    }

    public static ApiResponse<T> Create<T>(T? data, List<ApiError> errors)
    {
        return new ApiResponse<T> { Data = data, Errors = errors };
    }
}
