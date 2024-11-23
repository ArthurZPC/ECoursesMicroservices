using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
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
            .MustAsync(_categoryService.IsCategoryExists)
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryId_NotFound, x.Id));
    }
}
