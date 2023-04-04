// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;

namespace RestVladiola.Application.Warehouses.Commands.UpdateWarehouse;

public record UpdateWarehouseCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Position { get; init; }

    public int AllowedOrdersZero { get; init; }

    public bool Default { get; init; }

    public string Description { get; init; }
}

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateWarehouseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Warehouses
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Warehouse), request.Id);
        }

        entity.Id = request.Id;
        entity.Description = request.Description;
        entity.Default = request.Default;
        entity.Position = request.Position;
        entity.AllowedOrdersZero = request.AllowedOrdersZero;
        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}