using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
public class GetAuthorByIdQuery : IRequest<AuthorDto>
{
    public Guid Id { get; set; }
}
