using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class CreateTagCommand : IRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
