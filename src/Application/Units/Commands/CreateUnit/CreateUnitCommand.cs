// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Interfaces;
using RestVladiola.Domain.Events;
using Unit = RestVladiola.Domain.Entities.Unit;

namespace RestVladiola.Application.Units.Commands.CreateUnit;

public record CreateUnitCommand : IRequest<int>
{
    public int Id { get; init; }

    public string Abbreviation { get; init; }
}

public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateUnitCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        var entity = new Unit() { Id = request.Id, Abbreviation = request.Abbreviation };

        entity.AddDomainEvent(new UnitCreatedEvent(entity));

        _context.Units.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}