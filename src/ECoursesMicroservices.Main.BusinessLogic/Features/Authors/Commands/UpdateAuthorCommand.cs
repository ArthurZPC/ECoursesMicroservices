using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
public class UpdateAuthorCommand : IRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
