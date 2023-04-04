// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
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

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Id = request.Id,
            Count = request.Count,
            Delivery = request.Delivery,
            Description = request.Delivery,
            Dimensions = request.Dimensions,
            Discount = request.Discount,
            Display = request.Display,
            Kit = request.Kit,
            Photos = request.Photos,
            Price = request.Price,
            Price1 = request.Price1,
            Price2 = request.Price2,
            Title = request.Title,
            Weight = request.Weight,
            CategoryId = request.CategoryId,
            CategoryPromotion = request.CategoryPromotion,
            CountAccuracy = request.CountAccuracy,
            CountIncrement = request.CountIncrement,
            CountMin = request.CountMin,
            PreviousPrice = request.PreviousPrice,
            ProducerCode = request.ProducerCode,
            ProducerId = request.ProducerId,
            ProductSymbol = request.ProductSymbol,
            ToComparisons = request.ToComparisons,
            UnitId = request.UnitId,
            VatRate = request.VatRate,
            VendorCode = request.VendorCode,
            WarehouseCount = request.WarehouseCount,
            HtmlTitle = request.HtmlTitle,
            WarehouseId = request.WarehouseId
        };

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}