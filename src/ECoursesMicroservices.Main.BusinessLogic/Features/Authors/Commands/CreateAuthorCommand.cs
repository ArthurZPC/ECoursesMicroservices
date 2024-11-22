using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
public class CreateAuthorCommand : IRequest
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
