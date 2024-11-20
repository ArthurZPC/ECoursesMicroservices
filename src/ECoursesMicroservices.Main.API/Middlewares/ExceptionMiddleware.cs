using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Infrastructure.Models;
using FluentValidation;
using System.Net;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ECoursesMicroservices.Main.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private JsonSerializerOptions _serializerOptions;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _serializerOptions = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            var errors = ex.Errors
            .Select(x => new ApiError
            {
                Property = x.PropertyName,
                ErrorMessage = x.ErrorMessage
            })
            .ToList();

            await HandleExceptionAsync(context, 
                ApiResponseBuilder.Create<string>(null, errors), 
                HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            var apiError = new ApiError() { Property = string.Empty, ErrorMessage = ex.Message };
            await HandleExceptionAsync(context, 
                ApiResponseBuilder.Create<string>(null, new List<ApiError> { apiError }), 
                HttpStatusCode.InternalServerError);
        }
    }
    private async Task HandleExceptionAsync<T>(HttpContext context, ApiResponse<T> apiResponse, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var jsonContent = JsonSerializer.Serialize(apiResponse, _serializerOptions);

        await context.Response.WriteAsync(jsonContent);
    }
}
