// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Id)
            .NotEmpty();
    }
}