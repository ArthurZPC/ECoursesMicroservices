using ECoursesMicroservices.Infrastructure.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Validators;
public class PagedQueryValidator<T> : AbstractValidator<T> where T : PagedQuery
{
    public PagedQueryValidator()
    {
        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage(GlobalResources.PageSize_ShouldBeGreaterThanZero);

        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage(GlobalResources.PageNumber_ShouldBeGreaterThanZero);            
    }
}
