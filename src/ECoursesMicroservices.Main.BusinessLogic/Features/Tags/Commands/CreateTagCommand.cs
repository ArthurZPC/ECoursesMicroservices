using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class CreateTagCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
}
