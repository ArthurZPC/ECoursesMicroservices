using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class DeleteTagCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }
}
