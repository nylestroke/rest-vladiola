// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Producers.Queries.GetProducersWithPagination;

public class ProducerBriefItem : IMapFrom<Producer>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Keywords { get; init; }
}