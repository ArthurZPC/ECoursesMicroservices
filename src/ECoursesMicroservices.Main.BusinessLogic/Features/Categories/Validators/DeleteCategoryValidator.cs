using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.BusinessLogic.Resources;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Id)))
            .MustAsync(_categoryService.IsCategoryExists)
            .When(x => x.Id != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryId_NotFound, x.Id));
    }
}
