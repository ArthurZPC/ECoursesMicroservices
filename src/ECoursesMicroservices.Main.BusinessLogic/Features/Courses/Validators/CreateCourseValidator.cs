using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Infrastructure.Resources;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators;
public class CreateCourseValidator : AbstractValidator<CreateCourseCommand>
{
    private readonly ICourseService _courseService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthorService _authorService;
    private readonly ITagService _tagService;

    public CreateCourseValidator(ICourseService courseService,
        ICategoryService categoryService,
        IAuthorService authorService,
        ITagService tagService)
    {
        _courseService = courseService;
        _categoryService = categoryService;
        _authorService = authorService;
        _tagService = tagService;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Name)));

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.Description)));

        RuleFor(x => x.PublishDate)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.PublishDate)));

        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.AuthorId)))
            .MustAsync(_authorService.IsAuthorExists)
            .When(x => x.AuthorId != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(AuthorValidatorsResources.Author_AuthorId_NotFound, x.AuthorId));

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage(x => string.Format(GlobalResources.Field_Required, nameof(x.CategoryId)))
            .MustAsync(_categoryService.IsCategoryExists)
            .When(x => x.AuthorId != default, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => string.Format(CategoryValidatorsResources.Category_CategoryId_NotFound, x.CategoryId));

        RuleFor(x => x.Tags)
            .MustAsync(_tagService.AreTagsExists)
            .When(x => x.Tags != null && x.Tags.Count != 0, ApplyConditionTo.CurrentValidator)
            .WithMessage(x => CourseValidatorsResources.Course_Tags_NotFound);
    }
}
