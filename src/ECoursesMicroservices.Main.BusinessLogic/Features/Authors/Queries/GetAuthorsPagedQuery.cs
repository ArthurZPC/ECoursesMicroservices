using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
public class GetAuthorsPagedQuery : IRequest<PagedResult<AuthorDto>>, IPagedRequest
{
    public Guid? Id { get; set; }
    public Guid? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IncludeChild { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
