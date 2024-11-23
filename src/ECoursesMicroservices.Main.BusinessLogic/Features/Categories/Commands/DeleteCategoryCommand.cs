using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
public class DeleteCategoryCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }
}
