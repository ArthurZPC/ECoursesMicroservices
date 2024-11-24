using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
public class DeleteCourseCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }
}
