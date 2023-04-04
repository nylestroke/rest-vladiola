// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Entities;
using RestVladiola.Domain.Events;

namespace RestVladiola.Application.Warehouses.Commands.CreateWarehouse;

public record CreateWarehouseCommand : IRequest<int>
{
    public int Id { get; init; }

    public string Name { get; init; }

    public int Position { get; init; }

    public int AllowedOrdersZero { get; init; }

    public bool Default { get; init; }

    public string Description { get; init; }
}

public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateWarehouseCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var entity = new Warehouse
        {
            Id = request.Id,
            Description = request.Description,
            Default = request.Default,
            Position = request.Position,
            AllowedOrdersZero = request.AllowedOrdersZero,
            Name = request.Name
        };

        entity.AddDomainEvent(new WarehouseCreatedEvent(entity));

        _context.Warehouses.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}