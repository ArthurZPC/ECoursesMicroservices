using ECoursesMicroservices.Main.API.Middlewares;
using ECoursesMicroservices.Main.API.Settings;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
using ECoursesMicroservices.Main.BusinessLogic.Helpers;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Services;
using ECoursesMicroservices.Main.BusinessLogic.Validators;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(settings => 
    settings.CurrentConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.Configure<ApiBehaviorOptions>(settings => settings.SuppressModelStateInvalidFilter = true);

builder.Services.AddDbContext<ECoursesContext>((serviceProvider, options) =>
{
    var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
    options.UseSqlServer(appSettings.CurrentConnectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<MapperProfile>());
builder.Services.AddValidatorsFromAssemblyContaining<GetCategoryByIdValidator>(ServiceLifetime.Transient);
builder.Services.AddScoped(typeof(IValidator<>), typeof(PagedQueryValidator<>));

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.MapControllers();

app.Run();
