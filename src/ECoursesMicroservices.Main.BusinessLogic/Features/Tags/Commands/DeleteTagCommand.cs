using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
public class DeleteTagCommand : IRequest
{
    public Guid Id { get; set; }
}
