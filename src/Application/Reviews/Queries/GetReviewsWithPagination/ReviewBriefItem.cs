// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Enums;

namespace RestVladiola.Application.Reviews.Queries.GetReviewsWithPagination;

public class ReviewBriefItem : IMapFrom<Review>
{
    public int Id { get; init; }

    public int ProductId { get; init; }

    public Opinions Opinion { get; init; } = Opinions.Bad;

    public string Message { get; init; } = "";

    public string Name { get; init; }

    public string Email { get; init; }

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}