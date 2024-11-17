using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
public class GetAuthorsQuery : IRequest<IEnumerable<AuthorDto>>
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IncludeChild { get; set; }
}
