using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class UpdateTagCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}
