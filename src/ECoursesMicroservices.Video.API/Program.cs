using ECoursesMicroservices.Infrastructure;
using ECoursesMicroservices.Video.API.Settings;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Validators;
using ECoursesMicroservices.Video.BusinessLogic.Helpers;
using ECoursesMicroservices.Video.BusinessLogic.Interfaces;
using ECoursesMicroservices.Video.BusinessLogic.Options;
using ECoursesMicroservices.Video.BusinessLogic.Services;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(settings =>
    settings.CurrentConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.Configure<ApiBehaviorOptions>(settings => settings.SuppressModelStateInvalidFilter = true)
    .Configure<WebRootOptions>(options => options.WebRootLocation = builder.Configuration.GetValue<string>("WebRootLocation"));

builder.Services.AddDbContext<ECoursesVideoContext>((serviceProvider, options) =>
{
    var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
    options.UseSqlServer(appSettings.CurrentConnectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<MapperProfile>());
builder.Services.AddValidatorsFromAssemblyContaining<GetVideosByCourseIdQueryValidator>(ServiceLifetime.Transient);

builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddTransient<WebRootPathExtractor>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.Run();
