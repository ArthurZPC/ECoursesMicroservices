using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class UpdateTagCommand : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
