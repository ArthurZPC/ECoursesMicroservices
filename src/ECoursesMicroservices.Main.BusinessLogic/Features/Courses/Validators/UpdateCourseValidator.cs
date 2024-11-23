using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators.Resources;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using FluentValidation;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Validators;
public class UpdateCourseValidator : AbstractValidator<UpdateCourseCommand>
{
    private readonly ICourseService _courseService;
    private readonly ICategoryService _categoryService;
    private readonly IAuthorService _authorService;
    private readonly ITagService _tagService;

    public UpdateCourseValidator(ICourseService courseService,
        ICategoryService categoryService,
        IAuthorService authorService,
        ITagService tagService)
    {
        _courseService = courseService;
        _categoryService = categoryService;
        _authorService = authorService;
        _tagService = tagService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(_courseService.IsCourseExists)
            .WithMessage(x => string.Format(Resources.CourseValidatorsResources.Course_CourseId_NotFound, x.Id));

        RuleFor(x => x.PublishDate).NotEmpty();

        RuleFor(x => x.AuthorId)
            .NotEmpty()
            .MustAsync(_authorService.IsAuthorExists)
            .WithMessage(x => string.Format(AuthorValidatorsResources.Author_AuthorId_NotFound, x.AuthorId));

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .MustAsync(_categoryService.IsCategoryExists)
            .WithMessage(x => string.Format(CategoryValidatorsResources.Category_CategoryId_NotFound, x.CategoryId));

        RuleFor(x => x.Tags)
            .MustAsync(_tagService.AreTagsExists)
            .When(x => x.Tags != null && x.Tags.Count != 0)
            .WithMessage(x => CourseValidatorsResources.Course_Tags_NotFound);
    }
}
