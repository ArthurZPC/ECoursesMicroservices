﻿
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Validators;
public class GetAuthorByIdValidator : AbstractValidator<GetAuthorByIdQuery>
{
    private readonly IAuthorService _authorService;
    public GetAuthorByIdValidator(IAuthorService authorService)
    {
        _authorService = authorService;

        RuleFor(x => x.Id)
            .NotEmpty()
            .MustAsync(_authorService.IsAuthorExists)
            .WithMessage(x => string.Format(Resources.AuthorValidatorsResources.Author_AuthorId_NotFound, x.Id));
    }
}
