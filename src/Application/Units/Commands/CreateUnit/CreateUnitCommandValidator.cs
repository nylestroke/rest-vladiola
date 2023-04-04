// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Units.Commands.CreateUnit;

public class CreateUnitCommandValidator : AbstractValidator<CreateUnitCommand>
{
    public CreateUnitCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();

        RuleFor(v => v.Abbreviation)
            .NotEmpty();
    }
}