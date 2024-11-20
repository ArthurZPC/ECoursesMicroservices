using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
public class GetAuthorsPagedQuery : PagedQuery, IRequest<PagedResult<AuthorDto>>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
