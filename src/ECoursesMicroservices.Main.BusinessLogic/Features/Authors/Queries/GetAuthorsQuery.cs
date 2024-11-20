using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
