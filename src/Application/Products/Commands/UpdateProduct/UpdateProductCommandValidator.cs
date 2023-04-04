// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();

        RuleFor(v => v.Display)
            .NotEmpty();

        RuleFor(v => v.Count)
            .NotEmpty();

        RuleFor(v => v.Price)
            .NotEmpty();

        RuleFor(v => v.WarehouseCount)
            .NotEmpty();
    }
}