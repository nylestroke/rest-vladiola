// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using RestVladiola.Application.Common.Mappings;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Products.Queries.GetProductsWithPagination;

public class ProductBriefItem : IMapFrom<Product>
{
    public int Id { get; init; }

    public int CategoryId { get; init; }

    public int? ProducerId { get; init; }

    public int WarehouseId { get; init; }

    public int UnitId { get; init; }

    public float? Price { get; init; }

    public bool? Display { get; init; }

    public int? Kit { get; init; }

    public float? PreviousPrice { get; init; }

    public float? VatRate { get; init; }

    public float? Count { get; init; }

    public float? Weight { get; init; }

    public string? Dimensions { get; init; }

    public float? Price1 { get; init; }

    public float? Price2 { get; init; }

    public float? CountAccuracy { get; init; }

    public float? CountMin { get; init; }

    public float? CountIncrement { get; init; }

    public bool? ToComparisons { get; init; }

    public string? Title { get; init; }

    public string? VendorCode { get; init; }

    public string? ProducerCode { get; init; }

    public string? ProductSymbol { get; init; }

    public string? HtmlTitle { get; init; }

    public string? Description { get; init; }

    public string? CategoryPromotion { get; init; }

    public string? Delivery { get; init; }

    public object[]? Photos { get; init; }

    public object[]? WarehouseCount { get; init; }

    public int? Discount { get; init; }
}