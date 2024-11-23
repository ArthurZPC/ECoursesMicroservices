using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(_categoryService.IsCategoryExists)
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryId_NotFound, x.Id));

        RuleFor(x => x.Name)
            .NotEmpty()
            .MustAsync(async (name, token) => !await _categoryService.IsCategoryExists(name, token))
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryName_AlreadyExists, x.Name));
    }
}
