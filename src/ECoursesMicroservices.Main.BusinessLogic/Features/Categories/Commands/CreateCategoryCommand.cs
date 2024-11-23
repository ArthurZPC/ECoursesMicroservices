using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
public class CreateCategoryCommand : IRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
