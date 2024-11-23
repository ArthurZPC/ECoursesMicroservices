﻿using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators;
public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
{
    private readonly ICategoryService _categoryService;
    public GetCategoryByIdValidator(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(_categoryService.IsCategoryExists)
            .WithMessage(x => string.Format(Resources.CategoryValidatorsResources.Category_CategoryId_NotFound, x.Id));
    }
}
