using ECoursesMicroservices.Main.API.Middlewares;
using ECoursesMicroservices.Main.API.Settings;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
using ECoursesMicroservices.Main.BusinessLogic.Helpers;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(settings => 
    settings.CurrentConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddDbContext<ECoursesContext>((serviceProvider, options) =>
{
    var appSettings = serviceProvider.GetRequiredService<IOptions<AppSettings>>().Value;
    options.UseSqlServer(appSettings.CurrentConnectionString);
});

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<MapperProfile>());
builder.Services.AddValidatorsFromAssemblyContaining<GetCategoryByIdValidator>(ServiceLifetime.Transient);

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
