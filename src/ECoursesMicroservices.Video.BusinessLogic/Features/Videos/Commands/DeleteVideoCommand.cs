using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
public class DeleteVideoCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }
}
