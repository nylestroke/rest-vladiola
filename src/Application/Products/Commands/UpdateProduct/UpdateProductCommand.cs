// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public int Id { get; init; }

    public bool? Display { get; init; }

    public float? Price { get; init; }

    public float? Count { get; init; }

    public object[]? WarehouseCount { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.Id = request.Id;
        entity.Display = request.Display;
        entity.Price = request.Price;
        entity.Count = request.Count;
        entity.WarehouseCount = request.WarehouseCount;

        await _context.SaveChangesAsync(cancellationToken);
    }
}