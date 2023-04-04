// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using FluentValidation;

namespace RestVladiola.Application.Units.Queries.GetUnitsWithPagination;

public class GetUnitsPaginationQueryValidator : AbstractValidator<GetUnitsWithPaginationQuery>
{
    public GetUnitsPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}