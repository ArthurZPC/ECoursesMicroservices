using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
public class DeleteAuthorCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }
}
