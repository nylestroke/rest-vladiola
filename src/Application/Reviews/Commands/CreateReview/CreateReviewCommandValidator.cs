// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Reviews.Commands.CreateReview;

public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(40)
            .EmailAddress()
            .MinimumLength(8)
            .NotEmpty();

        RuleFor(v => v.Name)
            .MaximumLength(200)
            .MinimumLength(2)
            .NotEmpty();

        RuleFor(v => v.Message)
            .MaximumLength(200)
            .MinimumLength(20)
            .NotEmpty();

        RuleFor(v => v.ProductId)
            .NotEmpty();

        RuleFor(v => v.Id)
            .NotEmpty();
    }
}