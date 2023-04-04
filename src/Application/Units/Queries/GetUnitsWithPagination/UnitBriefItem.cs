// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using Unit = RestVladiola.Domain.Entities.Unit;

namespace RestVladiola.Application.Units.Queries.GetCategoriesWithPagination;

public class UnitBriefItem : IMapFrom<Unit>
{
    public int Id { get; init; }

    public string Abbreviation { get; init; }
}