// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Warehouses.Queries.GetWarehousesWithPagination;

public class WarehouseBriefItem : IMapFrom<Warehouse>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Position { get; init; }

    public int AllowedOrdersZero { get; init; }

    public bool Default { get; init; }

    public string Description { get; init; }
}