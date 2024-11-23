using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MustAsync(async (name, token) => !await _categoryService.IsCategoryExists(name, token))
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryName_AlreadyExists, x.Name));
    }
}
