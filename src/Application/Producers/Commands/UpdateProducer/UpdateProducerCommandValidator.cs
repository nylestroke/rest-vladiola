// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Producers.Commands.UpdateProducer;

public class UpdateProducerCommandValidator : AbstractValidator<UpdateProducerCommand>
{
    public UpdateProducerCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Id)
            .NotEmpty();
    }
}