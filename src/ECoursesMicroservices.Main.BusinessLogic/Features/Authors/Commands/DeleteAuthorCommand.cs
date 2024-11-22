using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
public class DeleteAuthorCommand : IRequest
{
    public Guid Id { get; set; }
}
