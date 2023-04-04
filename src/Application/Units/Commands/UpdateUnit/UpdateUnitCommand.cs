// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using MediatR;
using RestVladiola.Application.Common.Exceptions;
using RestVladiola.Application.Common.Interfaces;
using Unit = RestVladiola.Domain.Entities.Unit;

namespace RestVladiola.Application.Units.Commands.UpdateUnit;

public record UpdateUnitCommand : IRequest
{
    public int Id { get; init; }

    public string Abbreviation { get; init; }
}

public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUnitCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Units
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Unit), request.Id);
        }

        entity.Id = request.Id;
        entity.Abbreviation = request.Abbreviation;

        await _context.SaveChangesAsync(cancellationToken);
    }
}