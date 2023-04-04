// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Categories.Queries.GetCategoriesWithPagination;

public class CategoryBriefItem : IMapFrom<Category>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Position { get; init; }

    public float ProductWeight { get; init; }

    public float ProductDimension { get; init; }

    public float Kgo { get; init; }

    public string Path { get; init; }

    public string? Title { get; init; }

    public string? ShortDescription { get; init; }

    public string? Description { get; init; }
}